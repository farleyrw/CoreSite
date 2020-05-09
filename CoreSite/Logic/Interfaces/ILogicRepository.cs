using System.Collections.Generic;
using CoreSite.Base.Interfaces;
using CoreSite.Logic.Models;

namespace CoreSite.Logic.Interfaces
{
	public interface ILogicRepository : IRepository
    {
		List<Stuff> GetThings();
    }
}