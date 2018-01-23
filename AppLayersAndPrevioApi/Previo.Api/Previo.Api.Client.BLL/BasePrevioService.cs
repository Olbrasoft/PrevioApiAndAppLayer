using System;
using Previo.Api.Client.DAL;

namespace Previo.Api.Client.BLL
{
    
    /// <summary>
    /// aaa
    /// </summary>
    public abstract class BasePrevioService
    {
        protected BasePrevioService(IPrevioRepository repository)
        {
            Repository = repository;
        }

        protected string BuildHotIdSnippetXml(int hotId)
        {
            return String.Format("<hotId>{0}</hotId>", hotId);
        }

        protected IPrevioRepository Repository { get; set; }
    }
}