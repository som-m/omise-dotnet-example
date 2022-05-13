using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Omise;
using Omise.Models;

namespace omise_dotnet_example.Pages;

public class CheckoutModel : PageModel
{
	private readonly ILogger<CheckoutModel> _logger;

	public CheckoutModel(ILogger<CheckoutModel> logger)
	{
		_logger = logger;
	}

    [BindProperty]
    public string Id { get; set;}

	public void OnPost()
	{
        var omise = new Client(skey: "skey_test_");

        var charge = omise.Charges.Create(new CreateChargeRequest
        {
            Amount    = 2000,
            Currency  = "thb",
            Card      = Request.Form["omiseToken"]
        }).Result;

        Id = charge.Id;
	}
}
