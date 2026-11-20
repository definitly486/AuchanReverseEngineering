package me.leolin.shortcutbadger.impl;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.ShortcutBadgeException;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.util.BroadcastHelper;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class NewHtcHomeBadger implements Badger {
    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public void executeBadge(Context context, ComponentName componentName, int i) throws ShortcutBadgeException {
        boolean z;
        Intent intent = new Intent("com.htc.launcher.action.SET_NOTIFICATION");
        intent.putExtra("com.htc.launcher.extra.COMPONENT", componentName.flattenToShortString());
        intent.putExtra("com.htc.launcher.extra.COUNT", i);
        Intent intent2 = new Intent("com.htc.launcher.action.UPDATE_SHORTCUT");
        intent2.putExtra("packagename", componentName.getPackageName());
        intent2.putExtra("count", i);
        boolean z2 = false;
        try {
            BroadcastHelper.sendIntentExplicitly(context, intent);
            z = true;
        } catch (ShortcutBadgeException unused) {
            z = false;
        }
        try {
            BroadcastHelper.sendIntentExplicitly(context, intent2);
            z2 = true;
        } catch (ShortcutBadgeException unused2) {
        }
        if (z || z2) {
            return;
        }
        throw new ShortcutBadgeException("unable to resolve intent: " + intent2.toString());
    }

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public List getSupportLaunchers() {
        return Collections.singletonList("com.htc.launcher");
    }
}
