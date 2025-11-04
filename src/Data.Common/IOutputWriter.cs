using Core.Entities;

namespace Data.Common
{
    public interface IOutputWriter
    {
        void WriteResult(GameResult result);
    }
}
