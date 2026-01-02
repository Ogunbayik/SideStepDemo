using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerPresenter : IInitializable, ITickable, IDisposable
{
    private PlayerModel _model;
    private IPlayerView _view;

    public PlayerPresenter(PlayerModel model,IPlayerView view)
    {
        _model = model;
        _view = view;
    }
    public void Initialize()
    {

    }
    public void Dispose()
    {

    }

    public void Tick()
    {

    }
}
