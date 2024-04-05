public async Task<bool> CreateCommitAsync(string repo, string branch, string name, string data, string message)
{
    if (string.IsNullOrEmpty(repo) || string.IsNullOrEmpty(branch) ||
        string.IsNullOrEmpty(name) || string.IsNullOrEmpty(data) || string.IsNullOrEmpty(message))
    {
        // Log and handle invalid input
        Console.WriteLine("Invalid input parameters.");
        return false;
    }

    try
    {
        // Assuming 'git' is an instance of a class that handles git operations
        var git = new GitClient();

        // Switch to the desired branch
        await git.CheckoutBranchAsync(repo, branch);

        // Create a file with the provided 'name' and 'data'
        await git.CreateFileAsync(repo, name, data);

        // Commit the changes with the provided 'message'
        await git.CommitAsync(repo, message);

        Console.WriteLine("Commit created successfully.");
        return true;
    }
    catch (Exception ex)
    {
        // Log the exception details
        Console.WriteLine($"Error creating commit: {ex.Message}");
        return false;
    }
}
