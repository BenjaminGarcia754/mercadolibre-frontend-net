using frontendnet.Models;

namespace frontendnet.Services;

public class UsuariosClientService(HttpClient client)
{
    public async Task<List<Usuarios>?> GetAsync()
    {
        return await client.GetFromJsonAsync<List<Usuarios>>("api/usuarios");
    }

    public async Task<Usuarios?> GetAsync(string email)
    {
        return await client.GetFromJsonAsync<Usuarios>($"api/usuarios/{email}");
    }

    public async Task PostAsync(Usuarios usuario)
    {
        var response = await client.PostAsJsonAsync("api/utilidades", usuario);
        response.EnsureSuccessStatusCode();
    }

    public async Task PutAsync(Usuarios usuario)
    {
        var response = await client.PutAsJsonAsync($"api/usuarios/{usuario.Email}", usuario);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string email)
    {
        var response = await client.DeleteAsync($"api/usuarios/{email}");
        response.EnsureSuccessStatusCode();
    }
}
