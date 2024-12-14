using UnityEngine;

public class GameCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
{
    public int WinnerCount { get; private set; }

    public int LoseCount { get; private set; }

    private DIContainer _container;

    public GameCounterService(PlayerDataProvider playerDataProvider, DIContainer container)
    {
        playerDataProvider.RegisterWriter(this);
        playerDataProvider.RegisterReader(this);

        _container = container;
    }

    public void WinnerGame()
    {
        WinnerCount += 1;
        _container.Resolve<PlayerDataProvider>().Save();
        Debug.Log("� ������� � �������� 1 ������");
    }

    public void LoseGame()
    {
        LoseCount += 1;
        _container.Resolve<PlayerDataProvider>().Save();
        Debug.Log("� ������� � �������� 1 ���������");
    }

    public void ReadFrom(PlayerData data)
    {
        Debug.Log("� ����������");
        WinnerCount = data.CountWin;
        LoseCount = data.CountLose;
    }

    public void WriteTo(PlayerData data)
    {
        data.CountWin = WinnerCount;
        data.CountLose = LoseCount;
    }
}