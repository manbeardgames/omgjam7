//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dart.InternalCollections
//{
//    public class BitTagCollection
//    {
//        private List<Entity>[] _lists;
//        private bool[] _unsorted;
//        private bool _areAnyUnsorted;

//        public List<Entity> this[int index]
//        {
//            get { return _lists[index]; }
//        }

//        internal BitTagCollection()
//        {
//            _lists = new List<Entity>[BitTag._totalTags];
//            _unsorted = new bool[BitTag._totalTags];
//            for(int i = 0; i < _lists.Length; i++)
//            {
//                _lists[i] = new List<Entity>();
//            }
//        }

//        internal void MarkUnsorted(int index)
//        {
//            _areAnyUnsorted = true;
//            _unsorted[index] = true;
//        }

//        internal void UpdateCollection()
//        {
//            if(_areAnyUnsorted)
//            {
//                for(int i = 0; i < _lists.Length; i++)
//                {
//                    if(_unsorted[i])
//                    {
//                        _lists[i].Sort(EntityCollection.CompareDepth);
//                        _unsorted[i] = false;
//                    }
//                }

//                _areAnyUnsorted = false;
//            }
//        }

//        internal void EntityAdded(Entity entity)
//        {
//            for(int i = 0; i < _lists.Length; i++)
//            {
//                if(entity.TagCheck( 1 << i))
//                {
//                    this[i].Add(entity);
//                    _areAnyUnsorted = true;
//                    _unsorted[i] = true;
//                }
//            }
//        }

//        internal void EntityRemoved(Entity entity)
//        {
//            for(int i = 0; i < BitTag._totalTags; i++)
//            {
//                if(entity.TagCheck(1 << i))
//                {
//                    _lists[i].Remove(entity);
//                }
//            }
//        }


//    }
//}
