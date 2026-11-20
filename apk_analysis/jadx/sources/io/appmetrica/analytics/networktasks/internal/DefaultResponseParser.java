package io.appmetrica.analytics.networktasks.internal;

import androidx.core.app.NotificationCompat;
import com.bumptech.glide.load.Key;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public class DefaultResponseParser {

    public static class Response {
        public final String mStatus;

        public Response(String str) {
            this.mStatus = str;
        }

        public String toString() {
            return "Response{mStatus='" + this.mStatus + "'}";
        }
    }

    public Response parse(byte[] bArr) {
        if (bArr == null) {
            return null;
        }
        try {
            if (bArr.length > 0) {
                return new Response(new JSONObject(new String(bArr, Key.STRING_CHARSET_NAME)).optString(NotificationCompat.CATEGORY_STATUS));
            }
            return null;
        } catch (Throwable unused) {
            return null;
        }
    }
}
