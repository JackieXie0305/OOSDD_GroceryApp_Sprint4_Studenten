using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public abstract class Model : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected Model(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
