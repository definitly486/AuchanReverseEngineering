package androidx.lifecycle;

import android.view.View;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: View.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ViewKt {
    public static final /* synthetic */ LifecycleOwner findViewTreeLifecycleOwner(View view) {
        Intrinsics.checkNotNullParameter(view, "view");
        return ViewTreeLifecycleOwner.get(view);
    }
}
