using Lab14Crud.Database;
using Lab14Crud.Models;
using Lab14Crud.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14Crud.BL
{
    public class Components : IComponent
    {
        //Eliminar una fila
        public async Task<bool> Delete(ComponentModel componentModel)
        {
            using (var componentsContext = new ComponentContext())
            {
                var tracking = componentsContext.Remove(componentModel);
                await componentsContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
        }

        //Eliminar todo
        public async Task<bool> DeleteAllComponents()
        {
            using (var componentsContext = new ComponentContext())
            {
                componentsContext.RemoveRange(componentsContext.TbComponents);
                await componentsContext.SaveChangesAsync();
            }
            return true;
        }

        //Obtener la lista
        public async Task<List<ComponentModel>> GetListComponents()
        {
            using (var componentsContext = new ComponentContext())
            {
                return await componentsContext.TbComponents.ToListAsync();
            }
        }

        //Obtener un dato
        public async Task<ComponentModel> GetComponent(int ComponentId)
        {
            using (var componentsContext = new ComponentContext())
            {
                return await componentsContext.TbComponents.Where(p => p.IdComponentModel == ComponentId).FirstOrDefaultAsync();
            }
        }

        //Insertar una fila
        public async Task<bool> Insert(ComponentModel componentModel)
        {
            using (var componentContext = new ComponentContext())
            {
                componentContext.Add(componentModel);
                await componentContext.SaveChangesAsync();
            }
            return true;
        }

        //Actualizar una fila
        public async Task<bool> Update(ComponentModel componentModel)
        {
            using (var componentsContext = new ComponentContext())
            {
                var tracking = componentsContext.Update(componentModel);
                await componentsContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }
    }
}

