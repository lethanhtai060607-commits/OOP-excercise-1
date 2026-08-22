using System;
using System;
using System.Globalization;

public class UserAccount
{
    // Biến lưu mật khẩu và số dư
    private string _password;
    private decimal _balance;

    // 1. AccountId
    public string AccountId { get; init; }

    // 2. Username
    public string Username { get; set; }

    // 3. Password
    public string Password
    {
        set
        {
            _password = "[ENCRYPTED]_" + value;
        }
    }

    // 4. Balance
    public decimal Balance
    {
        get
        {
            return _balance;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
            else
            {
                _balance = value;
            }
        }
    }

    // 5. IsVIP
    public bool IsVIP => Balance >= 10000m;

    // 6. CreatedDate
    public DateTime CreatedDate { get; }

    // Hàm khởi tạo
    public UserAccount()
    {
        CreatedDate = DateTime.Now;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Định dạng tiền theo USD
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        // Tạo tài khoản
        UserAccount user = new UserAccount
        {
            AccountId = "31251024681",
            Username = "Le-Thanh-Tai",
            Password = "SuperSecretPassword123"
        };

        Console.WriteLine($"Account ID: {user.AccountId}");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Account Created: {user.CreatedDate}");

        // Kiểm tra Balance
        Console.WriteLine("\n--- Testing Balance Updates ---");

        user.Balance = 5000m;
        Console.WriteLine($"Current Balance: {user.Balance:C}");

        user.Balance = -200m;
        Console.WriteLine($"Current Balance after invalid attempt: {user.Balance:C}");

        // Kiểm tra IsVIP
        Console.WriteLine($"\nIs VIP? {user.IsVIP}");

        user.Balance = 15000m;
        Console.WriteLine($"Updated Balance: {user.Balance:C}");
        Console.WriteLine($"Is VIP now? {user.IsVIP}");
    }
}
