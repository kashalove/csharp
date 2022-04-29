using Api.ToDoApplication.Persistence;
using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using ListManagement.services;

namespace API.ListManagement.EC
{
    public class ToDoEC
    {
        public IEnumerable<ToDoDTO> Get()
        {
            return Filebase.Current.ToDos.Select(t => new ToDoDTO(t));
        }

        public ToDoDTO AddOrUpdate(ToDoDTO todo)
        {
            if (todo.Id <= 0)
            {
                //CREATE
                todo.Id = ItemService.Current.NextId;
                Filebase.Current.AddOrUpdate(new ToDo(todo));
            }
            else
            {
                //UPDATE
                var itemToUpdate = Filebase.Current.ToDos.FirstOrDefault(i => i.Id == todo.Id);
                if (itemToUpdate != null)
                {
                    var index = Filebase.Current.ToDos.FindIndex(i => i.Id == itemToUpdate.Id);
                    Filebase.Current.Delete((ToDo)itemToUpdate);
                    Filebase.Current.AddOrUpdate(new ToDo(todo));
                }
                else
                {
                    //CREATE -- Fall-Back
                    Filebase.Current.AddOrUpdate(new ToDo(todo));
                }
            }

            return todo;
        }

        public ToDoDTO Delete(int id)
        {
            var todoToDelete = Filebase.Current.ToDos.FirstOrDefault(i => i.Id == id);
            if(todoToDelete != null)
            {
                Filebase.Current.Delete((ToDo)todoToDelete);
            }

            return new ToDoDTO(todoToDelete);
        }
    }
}
