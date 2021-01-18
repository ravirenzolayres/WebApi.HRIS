using HrisApi.Data.Interface;
using HrisApi.Function.Interface;
using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FPosition : IFPosition
    {
        private readonly IDPosition _iDPosition;

        public FPosition(IDPosition iDPosition)
        {
            _iDPosition = iDPosition;
        }

        public async Task<Position> Add(string loggedUser, Position position)
        {
            position.CreatedBy = loggedUser;
            position.CreatedOn = DateTime.Now;

            await _iDPosition.Add(position);
            await _iDPosition.Complete();
            return await Task.FromResult(position);
        }

        public async Task<Position> Edit(string loggedUser,Position position)
        {
            position.UpdatedBy = loggedUser;
            position.UpdatedOn = DateTime.Now;

            await _iDPosition.Edit(position);
            await _iDPosition.Complete();
            return await Task.FromResult(position);
        }

        public async Task<Position> Delete(string loggedUser, Position position)
        {
            position.IsActive = false;
            position.DeletedBy = loggedUser;
            position.DeletedOn = DateTime.Now;

            await _iDPosition.Delete(position);
            await _iDPosition.Complete();
            return await Task.FromResult(position);
        }

        public async Task<Position> Get(int id)
        {
            return await _iDPosition.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<Position> Get(Func<Position, bool> condition)
        {
            return await _iDPosition.Get(condition);
        }

        public async Task<List<Position>> GetAll()
        {
            return await _iDPosition.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Position>> GetAll(Func<Position, bool> condition)
        {
            return await _iDPosition.GetAll(condition);
        }

        public async Task<int> GetCode(string positionCode)
        {
            var systemId = _iDPosition.Get(x => x.IsActive == true && x.PositionCode == positionCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
