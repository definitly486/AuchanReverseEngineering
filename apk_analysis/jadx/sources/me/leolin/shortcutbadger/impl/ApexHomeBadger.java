package me.leolin.shortcutbadger.impl;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.ShortcutBadgeException;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.util.BroadcastHelper;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class ApexHomeBadger implements Badger {
    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public void executeBadge(Context context, ComponentName componentName, int i) throws ShortcutBadgeException {
        Intent intent = new Intent("com.anddoes.launcher.COUNTER_CHANGED");
        intent.putExtra("package", componentName.getPackageName());
        intent.putExtra("count", i);
        intent.putExtra("class", componentName.getClassName());
        BroadcastHelper.sendIntentExplicitly(context, intent);
    }

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public List getSupportLaunchers() {
        return Arrays.asList("com.anddoes.launcher");
    }
}
