using System.Collections.Generic;
using System.Linq;
using CoreSite.Base;
using CoreSite.Logic.Interfaces;
using CoreSite.Logic.Models;

namespace CoreSite.Logic
{
	public class LogicRepository : BaseRepository<ILogicContext>, ILogicRepository
    {
		public LogicRepository(ILogicContext context) : base(context) { }

		public List<Stuff> GetThings()
		{
			var result = this.Context.Stuffs.ToList();

			return result;
		}
	}
}