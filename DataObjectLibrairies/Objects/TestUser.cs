using DataObjectLibrairies;
using DataObjectLibrairies.Enums;

namespace SampleApplication
{
    public class TestUser
    {
        public TestUser(Personat personat)
        {
            //when we will have multiple types of data objects, it will be interesting to extract the selection method
            //and put this in a DAO that will extract all values and return a table based on an ENUM of set values
            //and in this constructor, have a method that will set "name = table[0] lastname= table[1] etc
            //this will make data very managable and easy to maintain
            //this way, test cases will require NO maintenance !
            //we should still let the user define specific values too in his test case but not recommend it
            //Use random values could be interesting too
            switch (personat)
            {
                case Personat.YoungGuy:
                    FirstName = "Yuty";
                    LastName = "Shya";
                    GenderType = Gender.Male;

                    break;
                case Personat.OldGirl:
                    FirstName = "Old";
                    LastName = "girl";
                    GenderType = Gender.Male;
                    break;
                case Personat.SJW:
                    FirstName = "SomePerson";
                    LastName = "Lstname";
                    GenderType = Gender.Other;
                    break;
                default:
                    FirstName = "random";
                    LastName = "Name";
                    GenderType = Gender.Other;
                    break;
            }
        }
        public TestUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = LastName;
        }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender GenderType { get;set; }
    }
}