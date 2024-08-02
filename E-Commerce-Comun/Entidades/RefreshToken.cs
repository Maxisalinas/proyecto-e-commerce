using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Token { get; set; }
        public string IdJwt { get; set; }
        public bool Used { get; set; }
        public bool Revoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
