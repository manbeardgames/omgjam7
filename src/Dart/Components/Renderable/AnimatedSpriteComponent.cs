using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public class AnimatedSpriteComponent : SpriteComponent
    {
        //  The rate of playback for the animation. 1.0 is default/normal speed.
        private float _rate = 1.0f;

        //  Collection of all animations
        private Dictionary<string, Animation> _animations;

        //  The current animation that is playing
        private Animation _currentAnimation;

        //  The timer component used to manage timing frames.
        private float _animationTimer;

        //  A value indicating if the animation has played.
        private bool _played;

        /// <summary>
        ///     Gets or Sets the current frame of the animation playing.
        /// </summary>
        public int CurrentFrame { get; set; }

        /// <summary>
        ///     Gets or Sets a value that affects the animation speed.  1.0f is default/normal.
        /// </summary>
        public float Rate
        {
            get => _rate;
            set
            {
                if (_rate.Equals(value)) { return; }
                _rate = value;
            }
        }

        /// <summary>
        ///     Gets or Sets a value indicating if the internal timing component used for
        ///     playback uses the engine's raw delta time or normal delta time value.
        /// </summary>
        public bool UseRawDeltaTime { get; set; }

        /// <summary>
        ///     Gets or Sets an Action to invoke when an animation is finisehd.
        /// </summary>
        public Action<string> OnFinish { get; set; }

        /// <summary>
        ///     Gets or Sets an Action to invoke when an animation loops.
        /// </summary>
        public Action<string> OnLoop { get; set; }

        /// <summary>
        ///     Gets or Sets an Action to invoke when animation starts.
        /// </summary>
        public Action<string> OnAnimate { get; set; }

        /// <summary>
        ///     Gets the collection of VirtualTextures that represents the individual
        ///     frames of animation.
        /// </summary>
        public VirtualTexture2D[] Frames { get; private set; }

        /// <summary>
        ///     Gets a value indicating if this component is current animating.
        /// </summary>
        public bool Animating { get; private set; }

        /// <summary>
        ///     Gets a value that represents the ID of the current animation.
        /// </summary>
        public string CurrentAnimationID { get; private set; }

        /// <summary>
        ///     Gets the index of the current animation frame.
        /// </summary>
        public int CurrentAnimationFrame { get; private set; }

        /// <summary>
        ///     Gets the width of the animation in pixels.
        /// </summary>
        public override int Width => Frames.Length > 0 ? Frames[0].Width : 0;

        /// <summary>
        ///     Gets the height of the animation in pixels.
        /// </summary>
        public override int Height => Frames.Length > 0 ? Frames[0].Height : 0;


        public AnimatedSpriteComponent()
        {
            _animations = new Dictionary<string, Animation>();
        }

        public AnimatedSpriteComponent(VirtualTexture2D texture, int frameWidth, int frameHeight, int frameSep = 0)
        {
            VirtualTexture = texture;
            SetFrames(texture, frameWidth, frameHeight, frameSep);
            _animations = new Dictionary<string, Animation>();
        }

       


        public static AnimatedSpriteComponent FromAseprite(VirtualTexture2D texture, string contentPath)
        {
            string json = FileUtilities.ReadFile(contentPath);
            AsepriteJson aseprite = JsonUtilities.ReadToObject<AsepriteJson>(json);

            AnimatedSpriteComponent component = new AnimatedSpriteComponent();
            component.Frames = new VirtualTexture2D[aseprite.Frames.Length];

            for(int i = 0; i < aseprite.Meta.FrameTags.Length; i++)
            {
                AsepriteJson.AsepriteFrameTag tag = aseprite.Meta.FrameTags[i];

                int[] frames = new int[tag.To - tag.From + 1];

                for(int j = tag.From; j <= tag.To; j++)
                {
                    AsepriteJson.AsepriteRect frame = aseprite.Frames[j].Frame;

                    component.Frames[j] = texture.GetSubTexture(frame.X, frame.Y, frame.Width, frame.Height);
                    frames[j - tag.From] = j;
                }

                component.Add(tag.Name, true, aseprite.Frames[tag.From].Duration / 1000.0f, frames);
               
            }

            return component;

        }

        public void SetFrames(VirtualTexture2D texture, int frameWidth, int frameHeight, int frameSep = 0)
        {
            List<VirtualTexture2D> frames = new List<VirtualTexture2D>();
            int x = 0;
            int y = 0;

            while (y <= texture.Height - frameHeight)
            {
                while (x <= texture.Width - frameWidth)
                {
                    frames.Add(texture.GetSubTexture(x, y, frameWidth, frameHeight));
                    x += frameWidth + frameSep;
                }

                y += frameHeight + frameSep;
                x = 0;
            }

            Frames = frames.ToArray();
        }



        public override void Update()
        {
            if (Animating && _currentAnimation.Delay > 0)
            {
                //  Timer
                if (UseRawDeltaTime)
                {
                    _animationTimer += Engine.Time.RawDeltaTime * Rate;
                }
                else
                {
                    _animationTimer += Engine.Time.DeltaTime * Rate;
                }

                //  Next Frame
                if (Math.Abs(_animationTimer) >= _currentAnimation.Delay)
                {
                    CurrentAnimationFrame += Math.Sign(_animationTimer);
                    _animationTimer -= Math.Sign(_animationTimer) * _currentAnimation.Delay;

                    //  End of Animation
                    if (CurrentAnimationFrame < 0 || CurrentAnimationFrame >= _currentAnimation.Frames.Length)
                    {
                        //  Looped
                        if (_currentAnimation.Loop)
                        {
                            CurrentAnimationFrame -= Math.Sign(CurrentAnimationFrame) * _currentAnimation.Frames.Length;
                            CurrentFrame = _currentAnimation.Frames[CurrentAnimationFrame];

                            if (OnAnimate != null)
                            {
                                OnAnimate.Invoke(CurrentAnimationID);
                            }

                            if (OnLoop != null)
                            {
                                OnLoop.Invoke(CurrentAnimationID);
                            }
                        }
                        else
                        {
                            //  Ended
                            if (CurrentAnimationFrame < 0)
                            {
                                CurrentAnimationFrame = 0;
                            }
                            else
                            {
                                CurrentAnimationFrame = _currentAnimation.Frames.Length - 1;
                            }

                            Animating = false;
                            _animationTimer = 0;

                            if (OnFinish != null)
                            {
                                OnFinish.Invoke(CurrentAnimationID);
                            }
                        }
                    }
                    else
                    {
                        //  Continue Animation
                        CurrentFrame = _currentAnimation.Frames[CurrentAnimationFrame];
                        if (OnAnimate != null)
                        {
                            OnAnimate(CurrentAnimationID);
                        }
                    }
                }
            }
        }

        public override void Render()
        {
            VirtualTexture = Frames[CurrentFrame];
            base.Render();
        }

        public void Add(string id, bool loop, float delay, params int[] frames)
        {
            _animations[id] = new Animation()
            {
                Delay = delay,
                Frames = frames,
                Loop = loop
            };
        }

        public void Add(string id, float delay, params int[] frames)
        {
            Add(id, true, delay, frames);
        }

        public void Add(string id, int frame)
        {
            Add(id, false, 0.0f, frame);
        }

        public void ClearAnimation()
        {
            _animations.Clear();
        }

        public bool IsPlaying(string id)
        {
            if (!_played) { return false; }
            else if (CurrentAnimationID == null) { return id == null; }
            else { return CurrentAnimationID.Equals(id); }
        }

        public AnimatedSpriteComponent Play(string id, bool restart = false)
        {
            if (!IsPlaying(id) || restart)
            {
                CurrentAnimationID = id;
                _currentAnimation = _animations[id];
                _animationTimer = 0.0f;
                CurrentAnimationFrame = 0;
                _played = true;

                Animating = _currentAnimation.Frames.Length > 1;
                CurrentFrame = _currentAnimation.Frames[0];
            }
            return this;
        }

        public void Reverse(string id, bool restart = false)
        {
            Play(id, restart);
            if (Rate > 0)
            {
                Rate *= -1;
            }
        }

        public void Stop()
        {
            Animating = false;
            _played = false;
        }



        private struct Animation
        {
            public float Delay;
            public int[] Frames;
            public bool Loop;
        }

        [DataContract]
        public class AsepriteJson
        {
            [DataMember(Name = "frames")]
            public AsepriteFrame[] Frames { get; set; }

            [DataMember(Name = "meta")]
            public AsepriteMeta Meta { get; set; }


            [DataContract]
            public class AsepriteFrame
            {
                [DataMember(Name = "filename")]
                public string FileName { get; set; }

                [DataMember(Name = "frame")]
                public AsepriteRect Frame { get; set; }

                [DataMember(Name = "duration")]
                public int Duration { get; set; }

            }

            [DataContract]
            public class AsepriteMeta
            {
                [DataMember(Name = "frameTags")]
                public AsepriteFrameTag[] FrameTags { get; set; }
            }

            [DataContract]
            public class AsepriteFrameTag
            {
                [DataMember(Name = "name")]
                public string Name { get; set; }

                [DataMember(Name = "from")]
                public int From { get; set; }

                [DataMember(Name = "to")]
                public int To { get; set; }
            }

            [DataContract]
            public class AsepriteRect
            {
                [DataMember(Name = "x")]
                public int X { get; set; }

                [DataMember(Name = "y")]
                public int Y { get; set; }

                [DataMember(Name = "w")]
                public int Width { get; set; }

                [DataMember(Name = "h")]
                public int Height { get; set; }
            }
        }

    }
}
