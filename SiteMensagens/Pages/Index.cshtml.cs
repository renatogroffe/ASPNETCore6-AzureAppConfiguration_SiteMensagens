using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiteMensagens.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;

    public IndexModel(ILogger<IndexModel> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void OnGet()
    {
        var saudacao = _configuration["Mensagens:Saudacao"];
        TempData["Saudacao"] = saudacao;
        _logger.LogInformation($"Mensagens:Saudacao = {saudacao}");

        var aviso = _configuration["Mensagens:Aviso"];
        TempData["Aviso"] = aviso;
        _logger.LogInformation($"Mensagens:Saudacao = {aviso}");
    }
}