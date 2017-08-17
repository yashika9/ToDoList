using System;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using ToDoProject.Models;
using System.Net.Http.Headers;

namespace ToDoClient.Models
{
    public class TodoClient
    {
        private string BASE_URL = "http://localhost:61826/";

        public IEnumerable<Todo> displayAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Todo").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Todo>>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Todo display(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Todo/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Todo>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Create(Todo todo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/Todo",todo).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Edit(Todo todo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("api/Todo/" + todo.TaskId, todo).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/Todo/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}