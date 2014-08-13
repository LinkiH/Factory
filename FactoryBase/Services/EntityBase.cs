namespace Factory.Base.Services
{
    using Microsoft.Practices.Prism.Mvvm;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// EntityBase class
    /// </summary>
    public class EntityBase : BindableBase, IEntityBase
    {
        #region Private Properties
        

        #endregion

        #region Public Properties

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        #endregion

        #region Constructor
        ///// <summary>
        ///// Initializes a new instance of the <see cref="EntityBase"/> class.
        ///// </summary>
        //public EntityBase()
        //{

        //}
        #endregion

        ///// <summary>
        ///// Occurs when a property value changes.
        ///// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// Called when [property changed].
        ///// </summary>
        ///// <param name="name">The name.</param>
        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}
