package crc646064278e9258e0c4;

import androidx.biometric.BiometricPrompt;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AndroidBiometricService extends BiometricPrompt.AuthenticationCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onAuthenticationError(int i, CharSequence charSequence);

    private native void n_onAuthenticationSucceeded(BiometricPrompt.AuthenticationResult authenticationResult);

    public AndroidBiometricService() {
        if (getClass() == AndroidBiometricService.class) {
            TypeManager.Activate("Auchan.Android.Common.AndroidBiometricService, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.biometric.BiometricPrompt.AuthenticationCallback
    public void onAuthenticationError(int i, CharSequence charSequence) {
        n_onAuthenticationError(i, charSequence);
    }

    @Override // androidx.biometric.BiometricPrompt.AuthenticationCallback
    public void onAuthenticationSucceeded(BiometricPrompt.AuthenticationResult authenticationResult) {
        n_onAuthenticationSucceeded(authenticationResult);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
