using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.WebApi.Core.Controllers;
using InvilliaDDD.WebApi.Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.API.Controllers
{
    public partial class FriendsController
    {
        [HttpDelete("{id}")]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<ActionResult> Delete(Guid id)
        {
            return CustomResponse(await _friendAppService.Delete(id));
        }
    }
}
