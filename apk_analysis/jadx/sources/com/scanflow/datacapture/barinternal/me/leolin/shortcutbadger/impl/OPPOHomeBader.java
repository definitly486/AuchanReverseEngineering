package com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.impl;

import android.content.ComponentName;
import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.ShortcutBadgeException;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class OPPOHomeBader implements Badger {
    private int mCurrentTotalCount = -1;

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public void executeBadge(Context context, ComponentName componentName, int i) throws ShortcutBadgeException {
        if (this.mCurrentTotalCount == i) {
            return;
        }
        this.mCurrentTotalCount = i;
        executeBadgeByContentProvider(context, i);
    }

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public List getSupportLaunchers() {
        return Collections.singletonList("com.oppo.launcher");
    }

    private void executeBadgeByContentProvider(Context context, int i) throws ShortcutBadgeException {
        try {
            Bundle bundle = new Bundle();
            bundle.putInt("app_badge_count", i);
            context.getContentResolver().call(Uri.parse("content://com.android.badge/badge"), "setAppBadgeCount", (String) null, bundle);
        } catch (Throwable unused) {
            throw new ShortcutBadgeException("Unable to execute Badge By Content Provider");
        }
    }
}
