using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Shared.Users;

 public class UserResponseModel
 {
     public Guid Id { get; set; }

     public string Username { get; set; }

     public string Email { get; set; }

     public string FirstName { get; set; }

     public string LastName { get; set; }

     public string Address { get; set; }
 }

