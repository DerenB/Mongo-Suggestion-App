
namespace SuggestionAppLibrary.DataAccess;

public interface IStatusData
{
    Task CreationStatus(StatusModel status);
    Task<List<StatusModel>> GetAllStatuses();
}