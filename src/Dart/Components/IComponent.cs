namespace Dart
{
    public interface IComponent
    {
        /// <summary>
        ///     Gets the name of the component.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Called immediately after this component is added to the ComponentCollection
        ///     of a GameObject.  This method is useful for any initializations that the component
        ///     needs to perform but rely on the GameObject instance.  No guarentee is made to the
        ///     accessability of other Components on the GameObject here.  For relizances on other
        ///     Compoennts, see the Start() method.
        /// </summary>
        void Initialize(GameObject gameObject);

        /// <summary>
        ///     Called when this component has been removed from a GameObject.
        /// </summary>
        /// <param name="gameObject">
        ///     The GameObject this component was removed from.
        /// </param>
        void Removed(GameObject gameObject);

        /// <summary>
        ///     Called after Initizlie().  Gather references to other components on the entity here.
        /// </summary>
        void Start();
    }
}
