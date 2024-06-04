namespace SocialApplication;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
	}


	public class UserLogin
	{

		[PrimaryKey, AutoIncrement]
		public int userId { get; set; }
		public string? userName { get; set; }
		public int Phone { get; set; }
		public string? userEmail { get; set; }
		public string? Password { get; set; }
		public string? userType { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }


	}
}