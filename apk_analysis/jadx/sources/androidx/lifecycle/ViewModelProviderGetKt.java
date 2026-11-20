package androidx.lifecycle;

import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;

/* JADX INFO: compiled from: ViewModelProviderGet.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ViewModelProviderGetKt {
    public static final /* synthetic */ <VM extends ViewModel> VM get(ViewModelProvider viewModelProvider) {
        Intrinsics.checkNotNullParameter(viewModelProvider, "<this>");
        Intrinsics.reifiedOperationMarker(4, "VM");
        return (VM) viewModelProvider.get(Reflection.getOrCreateKotlinClass(ViewModel.class));
    }
}
