package com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.util;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ResolveInfo;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.ShortcutBadgeException;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BroadcastHelper {
    public static List resolveBroadcast(Context context, Intent intent) {
        List<ResolveInfo> listQueryBroadcastReceivers = context.getPackageManager().queryBroadcastReceivers(intent, 0);
        return listQueryBroadcastReceivers != null ? listQueryBroadcastReceivers : Collections.EMPTY_LIST;
    }

    public static void sendIntentExplicitly(Context context, Intent intent) throws ShortcutBadgeException {
        List<ResolveInfo> listResolveBroadcast = resolveBroadcast(context, intent);
        if (listResolveBroadcast.size() == 0) {
            throw new ShortcutBadgeException("unable to resolve intent: " + intent.toString());
        }
        for (ResolveInfo resolveInfo : listResolveBroadcast) {
            Intent intent2 = new Intent(intent);
            if (resolveInfo != null) {
                intent2.setPackage(resolveInfo.resolvePackageName);
                context.sendBroadcast(intent2);
            }
        }
    }

    public static void sendDefaultIntentExplicitly(Context context, Intent intent) throws ShortcutBadgeException {
        Intent intent2 = new Intent(intent);
        intent2.setAction("me.leolin.shortcutbadger.BADGE_COUNT_UPDATE");
        try {
            sendIntentExplicitly(context, intent2);
        } catch (ShortcutBadgeException unused) {
            sendIntentExplicitly(context, intent);
        }
    }
}
