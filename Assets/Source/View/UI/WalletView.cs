using Model.Currency;
using TMPro;
using UnityEngine;

namespace Source.View.UI
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;

        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnWalletBalanceChanged;

            OnWalletBalanceChanged();
        }

        private void OnDisable() => 
            _wallet.Changed -= OnWalletBalanceChanged;

        private void OnWalletBalanceChanged() => 
            _value.text = _wallet.Balance.ToString();
    }
}
