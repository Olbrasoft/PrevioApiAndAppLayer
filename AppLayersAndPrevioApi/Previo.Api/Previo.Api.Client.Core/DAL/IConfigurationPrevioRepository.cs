using System;

namespace Previo.Api.Client.DAL
{
    public interface IConfigurationPrevioRepository
    {
        string User { get; }
        string Password { get; }
        Uri BaseUrl { get; }
    }
}