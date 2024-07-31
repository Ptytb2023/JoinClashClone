using Model.Currency;
using Source.View.UI;
using Sources.CompositeRoot.Base;
using UnityEngine;

namespace Sources.CompositeRoot
{
	public class CurrencyCompositionRoot : BaseCompositionRoot
	{
		[SerializeField] private WalletView _walletView;
		
		public Wallet Wallet { get; private set; }
		
		public override void Compose()
		{
			Wallet = new Wallet(0);
			_walletView.Initialize(Wallet);
		}
	}
}