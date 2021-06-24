using System;
using System.Net.Http;
using System.Threading.Tasks;
using dotNetRogue.Data.Models;
using Newtonsoft.Json;

namespace dotNetRogue.Data
{
    public class ApiDecoder
    {

        // localhost url: https://localhost:44328

        public async Task<WeaponDTO> GenerateWeaponDto()
        {
            string url = "https://localhost:44328/weapon";
            using (HttpResponseMessage response = await APICaller.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var weaponDto = await response.Content.ReadAsAsync<WeaponDTO>();
                    return weaponDto;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
