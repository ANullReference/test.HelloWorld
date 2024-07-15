using MSME.Core.Domain;
using MSME.Infrastructure.Data.POCO;

namespace MSME.Infrastructure;

public static class Extensions
{
  public static Friends ToFriend(this Person person )
  {
    if (person is null)
      return null;


    return new Friends() {
        FirstName = person.first_name
      , LastName = person.last_name
      , Id = person.person_id
      , ImageUrl = person.image_url
    };


  }

  public static Person ToPerson(this Friends friend )
  {
    return new Person() {
      first_name = friend.FirstName, last_name = friend.LastName, person_id = friend.Id, image_url = friend.ImageUrl
    };
  }
}
