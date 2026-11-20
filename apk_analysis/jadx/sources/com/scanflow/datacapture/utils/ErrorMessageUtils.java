package com.scanflow.datacapture.utils;

/* JADX INFO: loaded from: classes3.dex */
public final class ErrorMessageUtils {
    public static final String Error_0 = "Please wait while your license key is being verified";
    public static final String Error_12 = "Error 12 - License Key Missing\nNo License key was set. Please set a valid license key";
    public static final String Error_13 = "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form.";
    public static final String Error_19 = "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app.";
    public static final String Error_9 = "Error 9, Error 10, Error 11 - Validation Failed\nPlease check your internet connection or contact administrator.";
    public static final ErrorMessageUtils INSTANCE = new ErrorMessageUtils();

    private ErrorMessageUtils() {
    }
}
