package androidx.lifecycle;

import android.view.View;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ViewTreeViewModel.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ViewTreeViewModelKt {
    public static final /* synthetic */ ViewModelStoreOwner findViewTreeViewModelStoreOwner(View view) {
        Intrinsics.checkNotNullParameter(view, "view");
        return ViewTreeViewModelStoreOwner.get(view);
    }
}
