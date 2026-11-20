package com.github.chrisbanes.photoview;

import android.view.View;

/* JADX INFO: loaded from: classes.dex */
abstract class Compat {
    public static void postOnAnimation(View view, Runnable runnable) {
        postOnAnimationJellyBean(view, runnable);
    }

    private static void postOnAnimationJellyBean(View view, Runnable runnable) {
        view.postOnAnimation(runnable);
    }
}
