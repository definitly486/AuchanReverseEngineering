package com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.impl;

import android.content.ComponentName;
import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class ZukHomeBadger implements Badger {
    private final Uri CONTENT_URI = Uri.parse("content://com.android.badge/badge");

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public void executeBadge(Context context, ComponentName componentName, int i) {
        Bundle bundle = new Bundle();
        bundle.putInt("app_badge_count", i);
        context.getContentResolver().call(this.CONTENT_URI, "setAppBadgeCount", (String) null, bundle);
    }

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public List getSupportLaunchers() {
        return Collections.singletonList("com.zui.launcher");
    }
}
