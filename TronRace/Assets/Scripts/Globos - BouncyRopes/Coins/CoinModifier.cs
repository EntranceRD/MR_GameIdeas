using Entrance.Movible;
using EntranceGames.Teleport;
using UnityEngine;

public enum CoinModifierType
{
    Upgrade,
    Degrade
}

namespace Entrance.Games.Coins
{

    public class CoinModifier : Mod
    {
        #region UNITY METHODS
        private void Start()
        {
            teleportable.OnTeleport += (newPoint) =>
            {
                movible.FindNewTarget();
            };
        }
        #endregion


        #region VARIABLES
        public CoinModifierType modType;
        [SerializeField] private TeleportableObject teleportable;
        [SerializeField] private MovibleElement movible;
        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS
        private int CoinModifierBehaviorByType(Balloon coinValue)
        {
            var value = coinValue.value;
            switch (modType)
            {
                case CoinModifierType.Upgrade:
                    switch (value)
                    {
                        case 1: return 2;
                        case 2: return 5;
                        case 5: return 10;
                        case 10: return 20;
                        case 20: return coinValue.maxValue;
                        default: return value;
                    }
                case CoinModifierType.Degrade:
                    switch (value)
                    {
                        case 1: return value;
                        case 2: return 1;
                        case 5: return 2;
                        case 10: return 5;
                        case 20: return 10;
                        default: return value;
                    }
            }
            return value;
        }

        private void ChangeCoinSize(Balloon coin)
        {
            var coinSize = coin.transform.localScale.x;
            var coinValue = coin.value;
            var newSize = 1f;

            switch (coinValue)
            {
                case 1: newSize = .3f; break;
                case 2: newSize = .7f; break;
                case 5: newSize = 1f; break;
                case 10: newSize = 1.3f; break;
                case 20: newSize = 1.5f; break;
                default: newSize = 1f; break;
            }

            var coinTransform = coin.transform;
            coinTransform.localScale = Vector3.one * 0.3f * newSize;
        }

        private void OnTriggerEnter(Collider other)
        {
            var balloon = other.GetComponent<Balloon>();
            if (balloon == null) return;

            balloon.value = CoinModifierBehaviorByType(balloon);
            ChangeCoinSize(balloon);
            balloon.OnValueChange?.Invoke();
            RecycleMod();
        }
        #endregion
    }
}