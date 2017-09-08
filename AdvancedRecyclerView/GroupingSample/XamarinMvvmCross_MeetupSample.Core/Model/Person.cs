using System;
namespace XamarinMvvmCross_MeetupSample.Core
{
	public class Person
	{
		public Person()
		{
		}

		public string GroupName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string PicturePath { get; set; }
		public bool IsSpecialPerson { get; set; }

		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var other = obj as Person;

			return other != null && other.ToString().Equals(ToString());
		}
	}
}
