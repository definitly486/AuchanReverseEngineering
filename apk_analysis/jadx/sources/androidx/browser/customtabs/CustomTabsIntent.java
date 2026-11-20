package androidx.browser.customtabs;

import android.app.ActivityOptions;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.IBinder;
import android.os.LocaleList;
import android.os.Parcelable;
import android.text.TextUtils;
import android.util.SparseArray;
import android.widget.RemoteViews;
import androidx.core.app.ActivityOptionsCompat;
import androidx.core.content.ContextCompat;
import com.google.common.net.HttpHeaders;
import java.util.ArrayList;
import java.util.Locale;

/* JADX INFO: loaded from: classes.dex */
public final class CustomTabsIntent {
    public final Intent intent;
    public final Bundle startAnimationBundle;

    public static int getMaxToolbarItems() {
        return 5;
    }

    public void launchUrl(Context context, Uri uri) {
        this.intent.setData(uri);
        ContextCompat.startActivity(context, this.intent, this.startAnimationBundle);
    }

    CustomTabsIntent(Intent intent, Bundle bundle) {
        this.intent = intent;
        this.startAnimationBundle = bundle;
    }

    public static final class Builder {
        private ArrayList mActionButtons;
        private ActivityOptions mActivityOptions;
        private SparseArray mColorSchemeParamBundles;
        private Bundle mDefaultColorSchemeBundle;
        private ArrayList mMenuItems;
        private boolean mShareIdentity;
        private final Intent mIntent = new Intent("android.intent.action.VIEW");
        private final CustomTabColorSchemeParams.Builder mDefaultColorSchemeBuilder = new CustomTabColorSchemeParams.Builder();
        private int mShareState = 0;
        private boolean mInstantAppsEnabled = true;

        public Builder() {
        }

        public Builder(CustomTabsSession customTabsSession) {
            if (customTabsSession != null) {
                setSession(customTabsSession);
            }
        }

        public Builder setSession(CustomTabsSession customTabsSession) {
            this.mIntent.setPackage(customTabsSession.getComponentName().getPackageName());
            setSessionParameters(customTabsSession.getBinder(), customTabsSession.getId());
            return this;
        }

        public Builder setPendingSession(CustomTabsSession.PendingSession pendingSession) {
            setSessionParameters(null, pendingSession.getId());
            return this;
        }

        private void setSessionParameters(IBinder iBinder, PendingIntent pendingIntent) {
            Bundle bundle = new Bundle();
            bundle.putBinder("android.support.customtabs.extra.SESSION", iBinder);
            if (pendingIntent != null) {
                bundle.putParcelable("android.support.customtabs.extra.SESSION_ID", pendingIntent);
            }
            this.mIntent.putExtras(bundle);
        }

        @Deprecated
        public Builder setToolbarColor(int i) {
            this.mDefaultColorSchemeBuilder.setToolbarColor(i);
            return this;
        }

        @Deprecated
        public Builder enableUrlBarHiding() {
            this.mIntent.putExtra("android.support.customtabs.extra.ENABLE_URLBAR_HIDING", true);
            return this;
        }

        public Builder setUrlBarHidingEnabled(boolean z) {
            this.mIntent.putExtra("android.support.customtabs.extra.ENABLE_URLBAR_HIDING", z);
            return this;
        }

        public Builder setCloseButtonIcon(Bitmap bitmap) {
            this.mIntent.putExtra("android.support.customtabs.extra.CLOSE_BUTTON_ICON", bitmap);
            return this;
        }

        public Builder setShowTitle(boolean z) {
            this.mIntent.putExtra("android.support.customtabs.extra.TITLE_VISIBILITY", z ? 1 : 0);
            return this;
        }

        public Builder addMenuItem(String str, PendingIntent pendingIntent) {
            if (this.mMenuItems == null) {
                this.mMenuItems = new ArrayList();
            }
            Bundle bundle = new Bundle();
            bundle.putString("android.support.customtabs.customaction.MENU_ITEM_TITLE", str);
            bundle.putParcelable("android.support.customtabs.customaction.PENDING_INTENT", pendingIntent);
            this.mMenuItems.add(bundle);
            return this;
        }

        @Deprecated
        public Builder addDefaultShareMenuItem() {
            setShareState(1);
            return this;
        }

        @Deprecated
        public Builder setDefaultShareMenuItemEnabled(boolean z) {
            if (z) {
                setShareState(1);
                return this;
            }
            setShareState(2);
            return this;
        }

        public Builder setShareState(int i) {
            if (i < 0 || i > 2) {
                throw new IllegalArgumentException("Invalid value for the shareState argument");
            }
            this.mShareState = i;
            if (i == 1) {
                this.mIntent.putExtra("android.support.customtabs.extra.SHARE_MENU_ITEM", true);
                return this;
            }
            if (i == 2) {
                this.mIntent.putExtra("android.support.customtabs.extra.SHARE_MENU_ITEM", false);
                return this;
            }
            this.mIntent.removeExtra("android.support.customtabs.extra.SHARE_MENU_ITEM");
            return this;
        }

        public Builder setActionButton(Bitmap bitmap, String str, PendingIntent pendingIntent, boolean z) {
            Bundle bundle = new Bundle();
            bundle.putInt("android.support.customtabs.customaction.ID", 0);
            bundle.putParcelable("android.support.customtabs.customaction.ICON", bitmap);
            bundle.putString("android.support.customtabs.customaction.DESCRIPTION", str);
            bundle.putParcelable("android.support.customtabs.customaction.PENDING_INTENT", pendingIntent);
            this.mIntent.putExtra("android.support.customtabs.extra.ACTION_BUTTON_BUNDLE", bundle);
            this.mIntent.putExtra("android.support.customtabs.extra.TINT_ACTION_BUTTON", z);
            return this;
        }

        public Builder setActionButton(Bitmap bitmap, String str, PendingIntent pendingIntent) {
            return setActionButton(bitmap, str, pendingIntent, false);
        }

        @Deprecated
        public Builder addToolbarItem(int i, Bitmap bitmap, String str, PendingIntent pendingIntent) {
            if (this.mActionButtons == null) {
                this.mActionButtons = new ArrayList();
            }
            if (this.mActionButtons.size() >= 5) {
                throw new IllegalStateException("Exceeded maximum toolbar item count of 5");
            }
            Bundle bundle = new Bundle();
            bundle.putInt("android.support.customtabs.customaction.ID", i);
            bundle.putParcelable("android.support.customtabs.customaction.ICON", bitmap);
            bundle.putString("android.support.customtabs.customaction.DESCRIPTION", str);
            bundle.putParcelable("android.support.customtabs.customaction.PENDING_INTENT", pendingIntent);
            this.mActionButtons.add(bundle);
            return this;
        }

        @Deprecated
        public Builder setSecondaryToolbarColor(int i) {
            this.mDefaultColorSchemeBuilder.setSecondaryToolbarColor(i);
            return this;
        }

        @Deprecated
        public Builder setNavigationBarColor(int i) {
            this.mDefaultColorSchemeBuilder.setNavigationBarColor(i);
            return this;
        }

        @Deprecated
        public Builder setNavigationBarDividerColor(int i) {
            this.mDefaultColorSchemeBuilder.setNavigationBarDividerColor(i);
            return this;
        }

        public Builder setSecondaryToolbarViews(RemoteViews remoteViews, int[] iArr, PendingIntent pendingIntent) {
            this.mIntent.putExtra("android.support.customtabs.extra.EXTRA_REMOTEVIEWS", remoteViews);
            this.mIntent.putExtra("android.support.customtabs.extra.EXTRA_REMOTEVIEWS_VIEW_IDS", iArr);
            this.mIntent.putExtra("android.support.customtabs.extra.EXTRA_REMOTEVIEWS_PENDINGINTENT", pendingIntent);
            return this;
        }

        public Builder setSecondaryToolbarSwipeUpGesture(PendingIntent pendingIntent) {
            this.mIntent.putExtra("androidx.browser.customtabs.extra.SECONDARY_TOOLBAR_SWIPE_UP_GESTURE", pendingIntent);
            return this;
        }

        public Builder setInstantAppsEnabled(boolean z) {
            this.mInstantAppsEnabled = z;
            return this;
        }

        public Builder setStartAnimations(Context context, int i, int i2) {
            this.mActivityOptions = ActivityOptions.makeCustomAnimation(context, i, i2);
            return this;
        }

        public Builder setExitAnimations(Context context, int i, int i2) {
            this.mIntent.putExtra("android.support.customtabs.extra.EXIT_ANIMATION_BUNDLE", ActivityOptionsCompat.makeCustomAnimation(context, i, i2).toBundle());
            return this;
        }

        public Builder setColorScheme(int i) {
            if (i < 0 || i > 2) {
                throw new IllegalArgumentException("Invalid value for the colorScheme argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.COLOR_SCHEME", i);
            return this;
        }

        public Builder setColorSchemeParams(int i, CustomTabColorSchemeParams customTabColorSchemeParams) {
            if (i < 0 || i > 2 || i == 0) {
                throw new IllegalArgumentException("Invalid colorScheme: " + i);
            }
            if (this.mColorSchemeParamBundles == null) {
                this.mColorSchemeParamBundles = new SparseArray();
            }
            this.mColorSchemeParamBundles.put(i, customTabColorSchemeParams.toBundle());
            return this;
        }

        public Builder setDefaultColorSchemeParams(CustomTabColorSchemeParams customTabColorSchemeParams) {
            this.mDefaultColorSchemeBundle = customTabColorSchemeParams.toBundle();
            return this;
        }

        public Builder setInitialActivityHeightPx(int i, int i2) {
            if (i <= 0) {
                throw new IllegalArgumentException("Invalid value for the initialHeightPx argument");
            }
            if (i2 < 0 || i2 > 2) {
                throw new IllegalArgumentException("Invalid value for the activityHeightResizeBehavior argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.INITIAL_ACTIVITY_HEIGHT_PX", i);
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_HEIGHT_RESIZE_BEHAVIOR", i2);
            return this;
        }

        public Builder setInitialActivityHeightPx(int i) {
            return setInitialActivityHeightPx(i, 0);
        }

        public Builder setInitialActivityWidthPx(int i) {
            if (i <= 0) {
                throw new IllegalArgumentException("Invalid value for the initialWidthPx argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.INITIAL_ACTIVITY_WIDTH_PX", i);
            return this;
        }

        public Builder setActivitySideSheetBreakpointDp(int i) {
            if (i <= 0) {
                throw new IllegalArgumentException("Invalid value for the initialWidthPx argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_BREAKPOINT_DP", i);
            return this;
        }

        public Builder setActivitySideSheetMaximizationEnabled(boolean z) {
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ENABLE_MAXIMIZATION", z);
            return this;
        }

        public Builder setActivitySideSheetPosition(int i) {
            if (i < 0 || i > 2) {
                throw new IllegalArgumentException("Invalid value for the sideSheetPosition argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_POSITION", i);
            return this;
        }

        public Builder setActivitySideSheetDecorationType(int i) {
            if (i < 0 || i > 3) {
                throw new IllegalArgumentException("Invalid value for the decorationType argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_DECORATION_TYPE", i);
            return this;
        }

        public Builder setActivitySideSheetRoundedCornersPosition(int i) {
            if (i < 0 || i > 2) {
                throw new IllegalArgumentException("Invalid value for the roundedCornersPosition./ argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ROUNDED_CORNERS_POSITION", i);
            return this;
        }

        public Builder setToolbarCornerRadiusDp(int i) {
            if (i < 0 || i > 16) {
                throw new IllegalArgumentException("Invalid value for the cornerRadiusDp argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.TOOLBAR_CORNER_RADIUS_DP", i);
            return this;
        }

        public Builder setCloseButtonPosition(int i) {
            if (i < 0 || i > 2) {
                throw new IllegalArgumentException("Invalid value for the position argument");
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.CLOSE_BUTTON_POSITION", i);
            return this;
        }

        public Builder setBookmarksButtonEnabled(boolean z) {
            this.mIntent.putExtra("org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_STAR_BUTTON", !z);
            return this;
        }

        public Builder setDownloadButtonEnabled(boolean z) {
            this.mIntent.putExtra("org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_DOWNLOAD_BUTTON", !z);
            return this;
        }

        public Builder setSendToExternalDefaultHandlerEnabled(boolean z) {
            this.mIntent.putExtra("android.support.customtabs.extra.SEND_TO_EXTERNAL_HANDLER", z);
            return this;
        }

        public Builder setTranslateLocale(Locale locale) {
            setLanguageTag(locale);
            return this;
        }

        public Builder setBackgroundInteractionEnabled(boolean z) {
            this.mIntent.putExtra("androidx.browser.customtabs.extra.DISABLE_BACKGROUND_INTERACTION", !z);
            return this;
        }

        public Builder setShareIdentityEnabled(boolean z) {
            this.mShareIdentity = z;
            return this;
        }

        public CustomTabsIntent build() {
            if (!this.mIntent.hasExtra("android.support.customtabs.extra.SESSION")) {
                setSessionParameters(null, null);
            }
            ArrayList<? extends Parcelable> arrayList = this.mMenuItems;
            if (arrayList != null) {
                this.mIntent.putParcelableArrayListExtra("android.support.customtabs.extra.MENU_ITEMS", arrayList);
            }
            ArrayList<? extends Parcelable> arrayList2 = this.mActionButtons;
            if (arrayList2 != null) {
                this.mIntent.putParcelableArrayListExtra("android.support.customtabs.extra.TOOLBAR_ITEMS", arrayList2);
            }
            this.mIntent.putExtra("android.support.customtabs.extra.EXTRA_ENABLE_INSTANT_APPS", this.mInstantAppsEnabled);
            this.mIntent.putExtras(this.mDefaultColorSchemeBuilder.build().toBundle());
            Bundle bundle = this.mDefaultColorSchemeBundle;
            if (bundle != null) {
                this.mIntent.putExtras(bundle);
            }
            if (this.mColorSchemeParamBundles != null) {
                Bundle bundle2 = new Bundle();
                bundle2.putSparseParcelableArray("androidx.browser.customtabs.extra.COLOR_SCHEME_PARAMS", this.mColorSchemeParamBundles);
                this.mIntent.putExtras(bundle2);
            }
            this.mIntent.putExtra("androidx.browser.customtabs.extra.SHARE_STATE", this.mShareState);
            int i = Build.VERSION.SDK_INT;
            setCurrentLocaleAsDefaultAcceptLanguage();
            if (i >= 34) {
                setShareIdentityEnabled();
            }
            ActivityOptions activityOptions = this.mActivityOptions;
            return new CustomTabsIntent(this.mIntent, activityOptions != null ? activityOptions.toBundle() : null);
        }

        private void setCurrentLocaleAsDefaultAcceptLanguage() {
            String defaultLocale = Api24Impl.getDefaultLocale();
            if (TextUtils.isEmpty(defaultLocale)) {
                return;
            }
            Bundle bundleExtra = this.mIntent.hasExtra("com.android.browser.headers") ? this.mIntent.getBundleExtra("com.android.browser.headers") : new Bundle();
            if (bundleExtra.containsKey(HttpHeaders.ACCEPT_LANGUAGE)) {
                return;
            }
            bundleExtra.putString(HttpHeaders.ACCEPT_LANGUAGE, defaultLocale);
            this.mIntent.putExtra("com.android.browser.headers", bundleExtra);
        }

        private void setLanguageTag(Locale locale) {
            Api21Impl.setLanguageTag(this.mIntent, locale);
        }

        private void setShareIdentityEnabled() {
            if (this.mActivityOptions == null) {
                this.mActivityOptions = Api23Impl.makeBasicActivityOptions();
            }
            Api34Impl.setShareIdentityEnabled(this.mActivityOptions, this.mShareIdentity);
        }
    }

    public static Intent setAlwaysUseBrowserUI(Intent intent) {
        if (intent == null) {
            intent = new Intent("android.intent.action.VIEW");
        }
        intent.addFlags(268435456);
        intent.putExtra("android.support.customtabs.extra.user_opt_out", true);
        return intent;
    }

    public static boolean shouldAlwaysUseBrowserUI(Intent intent) {
        return intent.getBooleanExtra("android.support.customtabs.extra.user_opt_out", false) && (intent.getFlags() & 268435456) != 0;
    }

    public static CustomTabColorSchemeParams getColorSchemeParams(Intent intent, int i) {
        Bundle bundle;
        if (i < 0 || i > 2 || i == 0) {
            throw new IllegalArgumentException("Invalid colorScheme: " + i);
        }
        Bundle extras = intent.getExtras();
        if (extras == null) {
            return CustomTabColorSchemeParams.fromBundle(null);
        }
        CustomTabColorSchemeParams customTabColorSchemeParamsFromBundle = CustomTabColorSchemeParams.fromBundle(extras);
        SparseArray sparseParcelableArray = extras.getSparseParcelableArray("androidx.browser.customtabs.extra.COLOR_SCHEME_PARAMS");
        return (sparseParcelableArray == null || (bundle = (Bundle) sparseParcelableArray.get(i)) == null) ? customTabColorSchemeParamsFromBundle : CustomTabColorSchemeParams.fromBundle(bundle).withDefaults(customTabColorSchemeParamsFromBundle);
    }

    public static int getActivityResizeBehavior(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.ACTIVITY_HEIGHT_RESIZE_BEHAVIOR", 0);
    }

    public static int getInitialActivityHeightPx(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.INITIAL_ACTIVITY_HEIGHT_PX", 0);
    }

    public static int getInitialActivityWidthPx(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.INITIAL_ACTIVITY_WIDTH_PX", 0);
    }

    public static int getActivitySideSheetBreakpointDp(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_BREAKPOINT_DP", 0);
    }

    public static boolean isActivitySideSheetMaximizationEnabled(Intent intent) {
        return intent.getBooleanExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ENABLE_MAXIMIZATION", false);
    }

    public static int getActivitySideSheetPosition(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_POSITION", 0);
    }

    public static int getActivitySideSheetDecorationType(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_DECORATION_TYPE", 0);
    }

    public static int getActivitySideSheetRoundedCornersPosition(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.ACTIVITY_SIDE_SHEET_ROUNDED_CORNERS_POSITION", 0);
    }

    public static int getToolbarCornerRadiusDp(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.TOOLBAR_CORNER_RADIUS_DP", 16);
    }

    public static int getCloseButtonPosition(Intent intent) {
        return intent.getIntExtra("androidx.browser.customtabs.extra.CLOSE_BUTTON_POSITION", 0);
    }

    public static boolean isBookmarksButtonEnabled(Intent intent) {
        return !intent.getBooleanExtra("org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_STAR_BUTTON", false);
    }

    public static boolean isDownloadButtonEnabled(Intent intent) {
        return !intent.getBooleanExtra("org.chromium.chrome.browser.customtabs.EXTRA_DISABLE_DOWNLOAD_BUTTON", false);
    }

    public static boolean isSendToExternalDefaultHandlerEnabled(Intent intent) {
        return intent.getBooleanExtra("android.support.customtabs.extra.SEND_TO_EXTERNAL_HANDLER", false);
    }

    public static Locale getTranslateLocale(Intent intent) {
        return getLocaleForLanguageTag(intent);
    }

    private static Locale getLocaleForLanguageTag(Intent intent) {
        return Api21Impl.getLocaleForLanguageTag(intent);
    }

    public static boolean isBackgroundInteractionEnabled(Intent intent) {
        return !intent.getBooleanExtra("androidx.browser.customtabs.extra.DISABLE_BACKGROUND_INTERACTION", false);
    }

    public static PendingIntent getSecondaryToolbarSwipeUpGesture(Intent intent) {
        return (PendingIntent) intent.getParcelableExtra("androidx.browser.customtabs.extra.SECONDARY_TOOLBAR_SWIPE_UP_GESTURE");
    }

    private static class Api21Impl {
        static void setLanguageTag(Intent intent, Locale locale) {
            intent.putExtra("androidx.browser.customtabs.extra.TRANSLATE_LANGUAGE_TAG", locale.toLanguageTag());
        }

        static Locale getLocaleForLanguageTag(Intent intent) {
            String stringExtra = intent.getStringExtra("androidx.browser.customtabs.extra.TRANSLATE_LANGUAGE_TAG");
            if (stringExtra != null) {
                return Locale.forLanguageTag(stringExtra);
            }
            return null;
        }
    }

    private static class Api23Impl {
        static ActivityOptions makeBasicActivityOptions() {
            return ActivityOptions.makeBasic();
        }
    }

    private static class Api24Impl {
        static String getDefaultLocale() {
            LocaleList adjustedDefault = LocaleList.getAdjustedDefault();
            if (adjustedDefault.size() > 0) {
                return adjustedDefault.get(0).toLanguageTag();
            }
            return null;
        }
    }

    private static class Api34Impl {
        static void setShareIdentityEnabled(ActivityOptions activityOptions, boolean z) {
            activityOptions.setShareIdentityEnabled(z);
        }
    }
}
