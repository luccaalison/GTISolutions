﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFServiceHost.Models
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceHost.Models")]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CPFField;
        
        private int ClienteIdField;
        
        private string DataExpedicaoField;
        
        private string DataNascimentoField;
        
        private WCFServiceHost.Models.EnderecoCliente EnderecoField;
        
        private string EstadoCivilField;
        
        private string NomeField;
        
        private string OrgaoExpedicaoField;
        
        private string RGField;
        
        private string SexoField;
        
        private string UFExpedicaoField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CPF
        {
            get
            {
                return this.CPFField;
            }
            set
            {
                this.CPFField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClienteId
        {
            get
            {
                return this.ClienteIdField;
            }
            set
            {
                this.ClienteIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataExpedicao
        {
            get
            {
                return this.DataExpedicaoField;
            }
            set
            {
                this.DataExpedicaoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataNascimento
        {
            get
            {
                return this.DataNascimentoField;
            }
            set
            {
                this.DataNascimentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WCFServiceHost.Models.EnderecoCliente Endereco
        {
            get
            {
                return this.EnderecoField;
            }
            set
            {
                this.EnderecoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EstadoCivil
        {
            get
            {
                return this.EstadoCivilField;
            }
            set
            {
                this.EstadoCivilField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome
        {
            get
            {
                return this.NomeField;
            }
            set
            {
                this.NomeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrgaoExpedicao
        {
            get
            {
                return this.OrgaoExpedicaoField;
            }
            set
            {
                this.OrgaoExpedicaoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RG
        {
            get
            {
                return this.RGField;
            }
            set
            {
                this.RGField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo
        {
            get
            {
                return this.SexoField;
            }
            set
            {
                this.SexoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UFExpedicao
        {
            get
            {
                return this.UFExpedicaoField;
            }
            set
            {
                this.UFExpedicaoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EnderecoCliente", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceHost.Models")]
    public partial class EnderecoCliente : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string BairroField;
        
        private string CEPField;
        
        private string CidadeField;
        
        private string ComplementoField;
        
        private int EnderecoClienteIdField;
        
        private string LogradouroField;
        
        private string NumeroField;
        
        private string UFField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Bairro
        {
            get
            {
                return this.BairroField;
            }
            set
            {
                this.BairroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CEP
        {
            get
            {
                return this.CEPField;
            }
            set
            {
                this.CEPField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cidade
        {
            get
            {
                return this.CidadeField;
            }
            set
            {
                this.CidadeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Complemento
        {
            get
            {
                return this.ComplementoField;
            }
            set
            {
                this.ComplementoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnderecoClienteId
        {
            get
            {
                return this.EnderecoClienteIdField;
            }
            set
            {
                this.EnderecoClienteIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Logradouro
        {
            get
            {
                return this.LogradouroField;
            }
            set
            {
                this.LogradouroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Numero
        {
            get
            {
                return this.NumeroField;
            }
            set
            {
                this.NumeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UF
        {
            get
            {
                return this.UFField;
            }
            set
            {
                this.UFField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IService")]
public interface IService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ObterClientes", ReplyAction="http://tempuri.org/IService/ObterClientesResponse")]
    WCFServiceHost.Models.Cliente[] ObterClientes();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ObterClientes", ReplyAction="http://tempuri.org/IService/ObterClientesResponse")]
    System.Threading.Tasks.Task<WCFServiceHost.Models.Cliente[]> ObterClientesAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdicionarCliente", ReplyAction="http://tempuri.org/IService/AdicionarClienteResponse")]
    void AdicionarCliente(WCFServiceHost.Models.Cliente cliente);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdicionarCliente", ReplyAction="http://tempuri.org/IService/AdicionarClienteResponse")]
    System.Threading.Tasks.Task AdicionarClienteAsync(WCFServiceHost.Models.Cliente cliente);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditarCliente", ReplyAction="http://tempuri.org/IService/EditarClienteResponse")]
    void EditarCliente(int clienteId, WCFServiceHost.Models.Cliente clienteAtualizado);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditarCliente", ReplyAction="http://tempuri.org/IService/EditarClienteResponse")]
    System.Threading.Tasks.Task EditarClienteAsync(int clienteId, WCFServiceHost.Models.Cliente clienteAtualizado);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExcluirCliente", ReplyAction="http://tempuri.org/IService/ExcluirClienteResponse")]
    void ExcluirCliente(int clienteId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExcluirCliente", ReplyAction="http://tempuri.org/IService/ExcluirClienteResponse")]
    System.Threading.Tasks.Task ExcluirClienteAsync(int clienteId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BuscarClientePorCPF", ReplyAction="http://tempuri.org/IService/BuscarClientePorCPFResponse")]
    WCFServiceHost.Models.Cliente BuscarClientePorCPF(string cpf);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BuscarClientePorCPF", ReplyAction="http://tempuri.org/IService/BuscarClientePorCPFResponse")]
    System.Threading.Tasks.Task<WCFServiceHost.Models.Cliente> BuscarClientePorCPFAsync(string cpf);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServiceChannel : IService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServiceClient : System.ServiceModel.ClientBase<IService>, IService
{
    
    public ServiceClient()
    {
    }
    
    public ServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public WCFServiceHost.Models.Cliente[] ObterClientes()
    {
        return base.Channel.ObterClientes();
    }
    
    public System.Threading.Tasks.Task<WCFServiceHost.Models.Cliente[]> ObterClientesAsync()
    {
        return base.Channel.ObterClientesAsync();
    }
    
    public void AdicionarCliente(WCFServiceHost.Models.Cliente cliente)
    {
        base.Channel.AdicionarCliente(cliente);
    }
    
    public System.Threading.Tasks.Task AdicionarClienteAsync(WCFServiceHost.Models.Cliente cliente)
    {
        return base.Channel.AdicionarClienteAsync(cliente);
    }
    
    public void EditarCliente(int clienteId, WCFServiceHost.Models.Cliente clienteAtualizado)
    {
        base.Channel.EditarCliente(clienteId, clienteAtualizado);
    }
    
    public System.Threading.Tasks.Task EditarClienteAsync(int clienteId, WCFServiceHost.Models.Cliente clienteAtualizado)
    {
        return base.Channel.EditarClienteAsync(clienteId, clienteAtualizado);
    }
    
    public void ExcluirCliente(int clienteId)
    {
        base.Channel.ExcluirCliente(clienteId);
    }
    
    public System.Threading.Tasks.Task ExcluirClienteAsync(int clienteId)
    {
        return base.Channel.ExcluirClienteAsync(clienteId);
    }
    
    public WCFServiceHost.Models.Cliente BuscarClientePorCPF(string cpf)
    {
        return base.Channel.BuscarClientePorCPF(cpf);
    }
    
    public System.Threading.Tasks.Task<WCFServiceHost.Models.Cliente> BuscarClientePorCPFAsync(string cpf)
    {
        return base.Channel.BuscarClientePorCPFAsync(cpf);
    }
}
