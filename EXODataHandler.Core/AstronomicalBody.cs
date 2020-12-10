namespace EXODataHandler.Core
{
    /// <summary>
    /// Class that saves the basic information of all AstronomicalBodys
    /// in the file
    /// </summary>
    public abstract class AstronomicalBody
    {
        /// <summary>
        /// Property use to get the AstronomicalBody's name
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Constructor for the AstronomicalBody class
        /// </summary>
        /// <param name="name">Name of the AstronomicalBody found 
        /// in the file</param>
        public AstronomicalBody(string name)
        {
            Name = name;
        }

    }
}
