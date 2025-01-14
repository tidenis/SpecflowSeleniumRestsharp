﻿using NUnit.Framework;
using RestSharp;
using SpecflowApiWeb.Models;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text.Json;
using WebMotorsApiWeb.Models;

namespace SpecflowApiWeb.Helpers
{
    public class RestSharpHelpers
    {
        private RestClient client;
        private RestRequest getRequest;
        private RestResponse getResponse;
        public List<ResponseMake> listResponseMake;
        public List<ResponseModel> listResponseModel;
        string endpoint;

        public void ConfiguraEndpoint(string endpoint)
        {
            this.endpoint = Constants.baseUrl + endpoint;
        }

        public void EnviaRequisicaoGet(string endpoint)
        {
            client = new RestClient(Constants.baseUrl + endpoint);
            getRequest = new RestRequest("", Method.Get);
            getRequest.AddHeader("Accept", "application/json");
            getRequest.RequestFormat = DataFormat.Json;

            getResponse = client.Execute(getRequest);
        }

        public void EnviaRequisicaoGet(string endpoint, Dictionary<string, int> headerKeyValuePairs)
        {            
            client = new RestClient(Constants.baseUrl + endpoint);
            getRequest = new RestRequest("", Method.Get);
            getRequest.AddHeader("Accept", "application/json");
            getRequest.RequestFormat = DataFormat.Json;           

            foreach (KeyValuePair<string, int> entry in headerKeyValuePairs)
            {
                getRequest.AddParameter(entry.Key, entry.Value);
            }

            getResponse = client.Execute(getRequest);
        }

        public void ValidaRetornoSucesso()
        {
            Assert.AreEqual(getResponse.StatusCode, HttpStatusCode.OK);
        }

        public void ValidaBodyResponseMake()
        {
            listResponseMake = JsonSerializer.Deserialize<List<ResponseMake>>(getResponse.Content);

            foreach (ResponseMake lista in listResponseMake)
            {
                Assert.IsNotNull(lista.ID);
                Assert.IsNotNull(lista.Name);                
            }
        }

        public void ValidaBodyResponseModel()
        {
            listResponseModel = JsonSerializer.Deserialize<List<ResponseModel>>(getResponse.Content);

            foreach (ResponseModel lista in listResponseModel)
            {
                Assert.IsNotNull(lista.MakeID);
                Assert.IsNotNull(lista.ID);
                Assert.IsNotNull(lista.Name);
            }
        }

        public int ConsultaMakeIDValido()
        {
            try
            {
                client = new RestClient(Constants.baseUrl + Constants.endpointMake);
                getRequest = new RestRequest("", Method.Get);
                getRequest.AddHeader("Accept", "application/json");
                getRequest.RequestFormat = DataFormat.Json;

                getResponse = client.Execute(getRequest);

                listResponseMake = JsonSerializer.Deserialize<List<ResponseMake>>(getResponse.Content);

            }catch(Exception)
            {
                throw new("Erro no Pré requisito");
            }

            return listResponseMake[0].ID;
        }
    }
}