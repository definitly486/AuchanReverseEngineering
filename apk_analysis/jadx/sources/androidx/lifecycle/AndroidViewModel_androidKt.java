package androidx.lifecycle;

import android.app.Application;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: AndroidViewModel.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class AndroidViewModel_androidKt {
    public static final Application getApplication(AndroidViewModel androidViewModel) {
        Intrinsics.checkNotNullParameter(androidViewModel, "<this>");
        return androidViewModel.getApplication();
    }
}
