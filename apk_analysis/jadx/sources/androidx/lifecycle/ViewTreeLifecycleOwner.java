package androidx.lifecycle;

import android.view.View;
import androidx.lifecycle.runtime.R;
import com.scanflow.datacapture.barinternal.androidx.core.viewtree.ViewTree;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ViewTreeLifecycleOwner.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ViewTreeLifecycleOwner {
    public static final void set(View view, LifecycleOwner lifecycleOwner) {
        Intrinsics.checkNotNullParameter(view, "<this>");
        view.setTag(R.id.view_tree_lifecycle_owner, lifecycleOwner);
    }

    public static final LifecycleOwner get(View view) {
        Intrinsics.checkNotNullParameter(view, "<this>");
        while (view != null) {
            Object tag = view.getTag(R.id.view_tree_lifecycle_owner);
            LifecycleOwner lifecycleOwner = tag instanceof LifecycleOwner ? (LifecycleOwner) tag : null;
            if (lifecycleOwner != null) {
                return lifecycleOwner;
            }
            Object parentOrViewTreeDisjointParent = ViewTree.getParentOrViewTreeDisjointParent(view);
            view = parentOrViewTreeDisjointParent instanceof View ? (View) parentOrViewTreeDisjointParent : null;
        }
        return null;
    }
}
