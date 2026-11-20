package me.leolin.shortcutbadger.impl;

import android.content.AsyncQueryHandler;
import android.content.ComponentName;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Looper;
import com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class SonyHomeBadger implements Badger {
    private final Uri BADGE_CONTENT_URI = Uri.parse("content://com.sonymobile.home.resourceprovider/badge");
    private AsyncQueryHandler mQueryHandler;

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public void executeBadge(Context context, ComponentName componentName, int i) {
        if (sonyBadgeContentProviderExists(context)) {
            executeBadgeByContentProvider(context, componentName, i);
        } else {
            executeBadgeByBroadcast(context, componentName, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.me.leolin.shortcutbadger.Badger
    public List getSupportLaunchers() {
        return Arrays.asList("com.sonyericsson.home", "com.sonymobile.home");
    }

    private static void executeBadgeByBroadcast(Context context, ComponentName componentName, int i) {
        Intent intent = new Intent("com.sonyericsson.home.action.UPDATE_BADGE");
        intent.putExtra("com.sonyericsson.home.intent.extra.badge.PACKAGE_NAME", componentName.getPackageName());
        intent.putExtra("com.sonyericsson.home.intent.extra.badge.ACTIVITY_NAME", componentName.getClassName());
        intent.putExtra("com.sonyericsson.home.intent.extra.badge.MESSAGE", String.valueOf(i));
        intent.putExtra("com.sonyericsson.home.intent.extra.badge.SHOW_MESSAGE", i > 0);
        context.sendBroadcast(intent);
    }

    private void executeBadgeByContentProvider(Context context, ComponentName componentName, int i) {
        if (i < 0) {
            return;
        }
        ContentValues contentValuesCreateContentValues = createContentValues(i, componentName);
        if (Looper.myLooper() == Looper.getMainLooper()) {
            if (this.mQueryHandler == null) {
                this.mQueryHandler = new AsyncQueryHandler(context.getApplicationContext().getContentResolver()) { // from class: me.leolin.shortcutbadger.impl.SonyHomeBadger.1
                };
            }
            insertBadgeAsync(contentValuesCreateContentValues);
            return;
        }
        insertBadgeSync(context, contentValuesCreateContentValues);
    }

    private void insertBadgeAsync(ContentValues contentValues) {
        this.mQueryHandler.startInsert(0, null, this.BADGE_CONTENT_URI, contentValues);
    }

    private void insertBadgeSync(Context context, ContentValues contentValues) {
        context.getApplicationContext().getContentResolver().insert(this.BADGE_CONTENT_URI, contentValues);
    }

    private ContentValues createContentValues(int i, ComponentName componentName) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("badge_count", Integer.valueOf(i));
        contentValues.put("package_name", componentName.getPackageName());
        contentValues.put("activity_name", componentName.getClassName());
        return contentValues;
    }

    private static boolean sonyBadgeContentProviderExists(Context context) {
        return context.getPackageManager().resolveContentProvider("com.sonymobile.home.resourceprovider", 0) != null;
    }
}
