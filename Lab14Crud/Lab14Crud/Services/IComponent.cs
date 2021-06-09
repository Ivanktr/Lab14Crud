using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14Crud.Services
{
    public interface ISinger
    {
        Task<List<ComponentModel>> GetListComponents();
        Task<ComponentModel> GetComponent(int ComponentId);
        Task<bool> Insert(ComponentModel componentModel);
        Task<bool> Update(ComponentModel componentModel);
        Task<bool> Delete(ComponentModel componentModel);
        Task<bool> DeleteAllComponents();
    }
}