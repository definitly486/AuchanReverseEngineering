package okhttp3;

import com.google.common.net.HttpHeaders;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.BuildConfig;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.internal.Util;

/* JADX INFO: compiled from: CacheControl.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class CacheControl {
    private String headerValue;
    private final boolean immutable;
    private final boolean isPrivate;
    private final boolean isPublic;
    private final int maxAgeSeconds;
    private final int maxStaleSeconds;
    private final int minFreshSeconds;
    private final boolean mustRevalidate;
    private final boolean noCache;
    private final boolean noStore;
    private final boolean noTransform;
    private final boolean onlyIfCached;
    private final int sMaxAgeSeconds;
    public static final Companion Companion = new Companion(null);
    public static final CacheControl FORCE_NETWORK = new Builder().noCache().build();
    public static final CacheControl FORCE_CACHE = new Builder().onlyIfCached().maxStale(Integer.MAX_VALUE, TimeUnit.SECONDS).build();

    public /* synthetic */ CacheControl(boolean z, boolean z2, int i, int i2, boolean z3, boolean z4, boolean z5, int i3, int i4, boolean z6, boolean z7, boolean z8, String str, DefaultConstructorMarker defaultConstructorMarker) {
        this(z, z2, i, i2, z3, z4, z5, i3, i4, z6, z7, z8, str);
    }

    public static final CacheControl parse(Headers headers) {
        return Companion.parse(headers);
    }

    private CacheControl(boolean z, boolean z2, int i, int i2, boolean z3, boolean z4, boolean z5, int i3, int i4, boolean z6, boolean z7, boolean z8, String str) {
        this.noCache = z;
        this.noStore = z2;
        this.maxAgeSeconds = i;
        this.sMaxAgeSeconds = i2;
        this.isPrivate = z3;
        this.isPublic = z4;
        this.mustRevalidate = z5;
        this.maxStaleSeconds = i3;
        this.minFreshSeconds = i4;
        this.onlyIfCached = z6;
        this.noTransform = z7;
        this.immutable = z8;
        this.headerValue = str;
    }

    public final boolean noCache() {
        return this.noCache;
    }

    public final boolean noStore() {
        return this.noStore;
    }

    public final int maxAgeSeconds() {
        return this.maxAgeSeconds;
    }

    public final int sMaxAgeSeconds() {
        return this.sMaxAgeSeconds;
    }

    public final boolean isPrivate() {
        return this.isPrivate;
    }

    public final boolean isPublic() {
        return this.isPublic;
    }

    public final boolean mustRevalidate() {
        return this.mustRevalidate;
    }

    public final int maxStaleSeconds() {
        return this.maxStaleSeconds;
    }

    public final int minFreshSeconds() {
        return this.minFreshSeconds;
    }

    public final boolean onlyIfCached() {
        return this.onlyIfCached;
    }

    public final boolean noTransform() {
        return this.noTransform;
    }

    public final boolean immutable() {
        return this.immutable;
    }

    /* JADX INFO: renamed from: -deprecated_noCache, reason: not valid java name */
    public final boolean m1015deprecated_noCache() {
        return this.noCache;
    }

    /* JADX INFO: renamed from: -deprecated_noStore, reason: not valid java name */
    public final boolean m1016deprecated_noStore() {
        return this.noStore;
    }

    /* JADX INFO: renamed from: -deprecated_maxAgeSeconds, reason: not valid java name */
    public final int m1011deprecated_maxAgeSeconds() {
        return this.maxAgeSeconds;
    }

    /* JADX INFO: renamed from: -deprecated_sMaxAgeSeconds, reason: not valid java name */
    public final int m1019deprecated_sMaxAgeSeconds() {
        return this.sMaxAgeSeconds;
    }

    /* JADX INFO: renamed from: -deprecated_mustRevalidate, reason: not valid java name */
    public final boolean m1014deprecated_mustRevalidate() {
        return this.mustRevalidate;
    }

    /* JADX INFO: renamed from: -deprecated_maxStaleSeconds, reason: not valid java name */
    public final int m1012deprecated_maxStaleSeconds() {
        return this.maxStaleSeconds;
    }

    /* JADX INFO: renamed from: -deprecated_minFreshSeconds, reason: not valid java name */
    public final int m1013deprecated_minFreshSeconds() {
        return this.minFreshSeconds;
    }

    /* JADX INFO: renamed from: -deprecated_onlyIfCached, reason: not valid java name */
    public final boolean m1018deprecated_onlyIfCached() {
        return this.onlyIfCached;
    }

    /* JADX INFO: renamed from: -deprecated_noTransform, reason: not valid java name */
    public final boolean m1017deprecated_noTransform() {
        return this.noTransform;
    }

    /* JADX INFO: renamed from: -deprecated_immutable, reason: not valid java name */
    public final boolean m1010deprecated_immutable() {
        return this.immutable;
    }

    public String toString() {
        String str = this.headerValue;
        if (str != null) {
            return str;
        }
        StringBuilder sb = new StringBuilder();
        if (this.noCache) {
            sb.append("no-cache, ");
        }
        if (this.noStore) {
            sb.append("no-store, ");
        }
        if (this.maxAgeSeconds != -1) {
            sb.append("max-age=");
            sb.append(this.maxAgeSeconds);
            sb.append(", ");
        }
        if (this.sMaxAgeSeconds != -1) {
            sb.append("s-maxage=");
            sb.append(this.sMaxAgeSeconds);
            sb.append(", ");
        }
        if (this.isPrivate) {
            sb.append("private, ");
        }
        if (this.isPublic) {
            sb.append("public, ");
        }
        if (this.mustRevalidate) {
            sb.append("must-revalidate, ");
        }
        if (this.maxStaleSeconds != -1) {
            sb.append("max-stale=");
            sb.append(this.maxStaleSeconds);
            sb.append(", ");
        }
        if (this.minFreshSeconds != -1) {
            sb.append("min-fresh=");
            sb.append(this.minFreshSeconds);
            sb.append(", ");
        }
        if (this.onlyIfCached) {
            sb.append("only-if-cached, ");
        }
        if (this.noTransform) {
            sb.append("no-transform, ");
        }
        if (this.immutable) {
            sb.append("immutable, ");
        }
        if (sb.length() == 0) {
            return "";
        }
        sb.delete(sb.length() - 2, sb.length());
        String string = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string, "StringBuilder().apply(builderAction).toString()");
        this.headerValue = string;
        return string;
    }

    /* JADX INFO: compiled from: CacheControl.kt */
    public static final class Builder {
        private boolean immutable;
        private int maxAgeSeconds = -1;
        private int maxStaleSeconds = -1;
        private int minFreshSeconds = -1;
        private boolean noCache;
        private boolean noStore;
        private boolean noTransform;
        private boolean onlyIfCached;

        private final int clampToInt(long j) {
            if (j > 2147483647L) {
                return Integer.MAX_VALUE;
            }
            return (int) j;
        }

        public final Builder noCache() {
            this.noCache = true;
            return this;
        }

        public final Builder noStore() {
            this.noStore = true;
            return this;
        }

        public final Builder maxAge(int i, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            if (i < 0) {
                throw new IllegalArgumentException(("maxAge < 0: " + i).toString());
            }
            this.maxAgeSeconds = clampToInt(timeUnit.toSeconds(i));
            return this;
        }

        public final Builder maxStale(int i, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            if (i < 0) {
                throw new IllegalArgumentException(("maxStale < 0: " + i).toString());
            }
            this.maxStaleSeconds = clampToInt(timeUnit.toSeconds(i));
            return this;
        }

        public final Builder minFresh(int i, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            if (i < 0) {
                throw new IllegalArgumentException(("minFresh < 0: " + i).toString());
            }
            this.minFreshSeconds = clampToInt(timeUnit.toSeconds(i));
            return this;
        }

        public final Builder onlyIfCached() {
            this.onlyIfCached = true;
            return this;
        }

        public final Builder noTransform() {
            this.noTransform = true;
            return this;
        }

        public final Builder immutable() {
            this.immutable = true;
            return this;
        }

        public final CacheControl build() {
            return new CacheControl(this.noCache, this.noStore, this.maxAgeSeconds, -1, false, false, false, this.maxStaleSeconds, this.minFreshSeconds, this.onlyIfCached, this.noTransform, this.immutable, null, null);
        }
    }

    /* JADX INFO: compiled from: CacheControl.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX WARN: Code duplicated, block: B:15:0x004b  */
        /* JADX WARN: Code duplicated, block: B:17:0x006a  */
        /* JADX WARN: Code duplicated, block: B:28:0x00cc  */
        /* JADX WARN: Code duplicated, block: B:32:0x00dc  */
        /* JADX WARN: Code duplicated, block: B:34:0x00e6  */
        /* JADX WARN: Code duplicated, block: B:36:0x00ee  */
        /* JADX WARN: Code duplicated, block: B:37:0x00f4  */
        /* JADX WARN: Code duplicated, block: B:39:0x00fc  */
        /* JADX WARN: Code duplicated, block: B:41:0x0106  */
        /* JADX WARN: Code duplicated, block: B:43:0x010e  */
        /* JADX WARN: Code duplicated, block: B:44:0x0114  */
        /* JADX WARN: Code duplicated, block: B:46:0x011c  */
        /* JADX WARN: Code duplicated, block: B:47:0x0122  */
        /* JADX WARN: Code duplicated, block: B:49:0x012a  */
        /* JADX WARN: Code duplicated, block: B:50:0x0130  */
        /* JADX WARN: Code duplicated, block: B:52:0x0138  */
        /* JADX WARN: Code duplicated, block: B:53:0x013f  */
        /* JADX WARN: Code duplicated, block: B:55:0x0147  */
        /* JADX WARN: Code duplicated, block: B:56:0x014f  */
        /* JADX WARN: Code duplicated, block: B:58:0x0157  */
        /* JADX WARN: Code duplicated, block: B:59:0x015d  */
        /* JADX WARN: Code duplicated, block: B:61:0x0166  */
        /* JADX WARN: Code duplicated, block: B:62:0x016e  */
        /* JADX WARN: Code duplicated, block: B:64:0x0176  */
        /* JADX WARN: Code duplicated, block: B:65:0x017e  */
        /* JADX WARN: Code duplicated, block: B:67:0x0186  */
        public final CacheControl parse(Headers headers) {
            int iIndexOfElement;
            int iIndexOfElement2;
            boolean z;
            String string;
            int i;
            String str;
            String string2;
            Headers headers2 = headers;
            Intrinsics.checkNotNullParameter(headers2, "headers");
            int size = headers2.size();
            boolean z2 = true;
            boolean z3 = true;
            int i2 = 0;
            String str2 = null;
            boolean z4 = false;
            boolean z5 = false;
            int nonNegativeInt = -1;
            int nonNegativeInt2 = -1;
            boolean z6 = false;
            boolean z7 = false;
            boolean z8 = false;
            int nonNegativeInt3 = -1;
            int nonNegativeInt4 = -1;
            boolean z9 = false;
            boolean z10 = false;
            boolean z11 = false;
            while (i2 < size) {
                String strName = headers2.name(i2);
                String strValue = headers2.value(i2);
                if (!StringsKt.equals(strName, HttpHeaders.CACHE_CONTROL, z2)) {
                    if (StringsKt.equals(strName, HttpHeaders.PRAGMA, z2)) {
                    }
                    i2++;
                    headers2 = headers;
                    z2 = z2;
                    size = size;
                } else {
                    if (str2 == null) {
                        str2 = strValue;
                    }
                    iIndexOfElement = 0;
                    while (iIndexOfElement < strValue.length()) {
                        iIndexOfElement2 = indexOfElement(strValue, "=,;", iIndexOfElement);
                        String strSubstring = strValue.substring(iIndexOfElement, iIndexOfElement2);
                        z = z2;
                        Intrinsics.checkNotNullExpressionValue(strSubstring, "this as java.lang.String…ing(startIndex, endIndex)");
                        string = StringsKt.trim(strSubstring).toString();
                        if (iIndexOfElement2 != strValue.length()) {
                            i = size;
                            if (strValue.charAt(iIndexOfElement2) == ',' && strValue.charAt(iIndexOfElement2) != ';') {
                                int iIndexOfNonWhitespace = Util.indexOfNonWhitespace(strValue, iIndexOfElement2 + 1);
                                if (iIndexOfNonWhitespace < strValue.length() && strValue.charAt(iIndexOfNonWhitespace) == '\"') {
                                    int i3 = iIndexOfNonWhitespace + 1;
                                    String str3 = strValue;
                                    int iIndexOf$default = StringsKt.indexOf$default((CharSequence) str3, '\"', i3, false, 4, (Object) null);
                                    str = str3;
                                    String strSubstring2 = str.substring(i3, iIndexOf$default);
                                    Intrinsics.checkNotNullExpressionValue(strSubstring2, "this as java.lang.String…ing(startIndex, endIndex)");
                                    iIndexOfElement = iIndexOf$default + 1;
                                    string2 = strSubstring2;
                                } else {
                                    str = strValue;
                                    iIndexOfElement = indexOfElement(str, ",;", iIndexOfNonWhitespace);
                                    String strSubstring3 = str.substring(iIndexOfNonWhitespace, iIndexOfElement);
                                    Intrinsics.checkNotNullExpressionValue(strSubstring3, "this as java.lang.String…ing(startIndex, endIndex)");
                                    string2 = StringsKt.trim(strSubstring3).toString();
                                }
                            }
                            if (StringsKt.equals("no-cache", string, z)) {
                                z2 = z;
                                z4 = z2;
                            } else if (StringsKt.equals("no-store", string, z)) {
                                z2 = z;
                                z5 = z2;
                            } else {
                                if (StringsKt.equals("max-age", string, z)) {
                                    nonNegativeInt = Util.toNonNegativeInt(string2, -1);
                                } else if (StringsKt.equals("s-maxage", string, z)) {
                                    nonNegativeInt2 = Util.toNonNegativeInt(string2, -1);
                                } else if (StringsKt.equals("private", string, z)) {
                                    z2 = z;
                                    z6 = z2;
                                } else if (StringsKt.equals(BuildConfig.SDK_BUILD_FLAVOR, string, z)) {
                                    z2 = z;
                                    z7 = z2;
                                } else if (StringsKt.equals("must-revalidate", string, z)) {
                                    z2 = z;
                                    z8 = z2;
                                } else if (StringsKt.equals("max-stale", string, z)) {
                                    nonNegativeInt3 = Util.toNonNegativeInt(string2, Integer.MAX_VALUE);
                                } else if (StringsKt.equals("min-fresh", string, z)) {
                                    nonNegativeInt4 = Util.toNonNegativeInt(string2, -1);
                                } else if (StringsKt.equals("only-if-cached", string, z)) {
                                    z2 = z;
                                    z9 = z2;
                                } else if (StringsKt.equals("no-transform", string, z)) {
                                    z2 = z;
                                    z10 = z2;
                                } else if (StringsKt.equals("immutable", string, z)) {
                                    z2 = z;
                                    z11 = z2;
                                }
                                z2 = z;
                            }
                            strValue = str;
                            size = i;
                        } else {
                            i = size;
                        }
                        str = strValue;
                        iIndexOfElement = iIndexOfElement2 + 1;
                        string2 = null;
                        if (StringsKt.equals("no-cache", string, z)) {
                            z2 = z;
                            z4 = z2;
                        } else if (StringsKt.equals("no-store", string, z)) {
                            z2 = z;
                            z5 = z2;
                        } else {
                            if (StringsKt.equals("max-age", string, z)) {
                                nonNegativeInt = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("s-maxage", string, z)) {
                                nonNegativeInt2 = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("private", string, z)) {
                                z2 = z;
                                z6 = z2;
                            } else if (StringsKt.equals(BuildConfig.SDK_BUILD_FLAVOR, string, z)) {
                                z2 = z;
                                z7 = z2;
                            } else if (StringsKt.equals("must-revalidate", string, z)) {
                                z2 = z;
                                z8 = z2;
                            } else if (StringsKt.equals("max-stale", string, z)) {
                                nonNegativeInt3 = Util.toNonNegativeInt(string2, Integer.MAX_VALUE);
                            } else if (StringsKt.equals("min-fresh", string, z)) {
                                nonNegativeInt4 = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("only-if-cached", string, z)) {
                                z2 = z;
                                z9 = z2;
                            } else if (StringsKt.equals("no-transform", string, z)) {
                                z2 = z;
                                z10 = z2;
                            } else if (StringsKt.equals("immutable", string, z)) {
                                z2 = z;
                                z11 = z2;
                            }
                            z2 = z;
                        }
                        strValue = str;
                        size = i;
                    }
                    i2++;
                    headers2 = headers;
                    z2 = z2;
                    size = size;
                }
                z3 = false;
                iIndexOfElement = 0;
                while (iIndexOfElement < strValue.length()) {
                    iIndexOfElement2 = indexOfElement(strValue, "=,;", iIndexOfElement);
                    String strSubstring4 = strValue.substring(iIndexOfElement, iIndexOfElement2);
                    z = z2;
                    Intrinsics.checkNotNullExpressionValue(strSubstring4, "this as java.lang.String…ing(startIndex, endIndex)");
                    string = StringsKt.trim(strSubstring4).toString();
                    if (iIndexOfElement2 != strValue.length()) {
                        i = size;
                        if (strValue.charAt(iIndexOfElement2) == ',') {
                        }
                        if (StringsKt.equals("no-cache", string, z)) {
                            z2 = z;
                            z4 = z2;
                        } else if (StringsKt.equals("no-store", string, z)) {
                            z2 = z;
                            z5 = z2;
                        } else {
                            if (StringsKt.equals("max-age", string, z)) {
                                nonNegativeInt = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("s-maxage", string, z)) {
                                nonNegativeInt2 = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("private", string, z)) {
                                z2 = z;
                                z6 = z2;
                            } else if (StringsKt.equals(BuildConfig.SDK_BUILD_FLAVOR, string, z)) {
                                z2 = z;
                                z7 = z2;
                            } else if (StringsKt.equals("must-revalidate", string, z)) {
                                z2 = z;
                                z8 = z2;
                            } else if (StringsKt.equals("max-stale", string, z)) {
                                nonNegativeInt3 = Util.toNonNegativeInt(string2, Integer.MAX_VALUE);
                            } else if (StringsKt.equals("min-fresh", string, z)) {
                                nonNegativeInt4 = Util.toNonNegativeInt(string2, -1);
                            } else if (StringsKt.equals("only-if-cached", string, z)) {
                                z2 = z;
                                z9 = z2;
                            } else if (StringsKt.equals("no-transform", string, z)) {
                                z2 = z;
                                z10 = z2;
                            } else if (StringsKt.equals("immutable", string, z)) {
                                z2 = z;
                                z11 = z2;
                            }
                            z2 = z;
                        }
                        strValue = str;
                        size = i;
                    } else {
                        i = size;
                    }
                    str = strValue;
                    iIndexOfElement = iIndexOfElement2 + 1;
                    string2 = null;
                    if (StringsKt.equals("no-cache", string, z)) {
                        z2 = z;
                        z4 = z2;
                    } else if (StringsKt.equals("no-store", string, z)) {
                        z2 = z;
                        z5 = z2;
                    } else {
                        if (StringsKt.equals("max-age", string, z)) {
                            nonNegativeInt = Util.toNonNegativeInt(string2, -1);
                        } else if (StringsKt.equals("s-maxage", string, z)) {
                            nonNegativeInt2 = Util.toNonNegativeInt(string2, -1);
                        } else if (StringsKt.equals("private", string, z)) {
                            z2 = z;
                            z6 = z2;
                        } else if (StringsKt.equals(BuildConfig.SDK_BUILD_FLAVOR, string, z)) {
                            z2 = z;
                            z7 = z2;
                        } else if (StringsKt.equals("must-revalidate", string, z)) {
                            z2 = z;
                            z8 = z2;
                        } else if (StringsKt.equals("max-stale", string, z)) {
                            nonNegativeInt3 = Util.toNonNegativeInt(string2, Integer.MAX_VALUE);
                        } else if (StringsKt.equals("min-fresh", string, z)) {
                            nonNegativeInt4 = Util.toNonNegativeInt(string2, -1);
                        } else if (StringsKt.equals("only-if-cached", string, z)) {
                            z2 = z;
                            z9 = z2;
                        } else if (StringsKt.equals("no-transform", string, z)) {
                            z2 = z;
                            z10 = z2;
                        } else if (StringsKt.equals("immutable", string, z)) {
                            z2 = z;
                            z11 = z2;
                        }
                        z2 = z;
                    }
                    strValue = str;
                    size = i;
                }
                i2++;
                headers2 = headers;
                z2 = z2;
                size = size;
            }
            return new CacheControl(z4, z5, nonNegativeInt, nonNegativeInt2, z6, z7, z8, nonNegativeInt3, nonNegativeInt4, z9, z10, z11, !z3 ? null : str2, null);
        }

        static /* synthetic */ int indexOfElement$default(Companion companion, String str, String str2, int i, int i2, Object obj) {
            if ((i2 & 2) != 0) {
                i = 0;
            }
            return companion.indexOfElement(str, str2, i);
        }

        private final int indexOfElement(String str, String str2, int i) {
            int length = str.length();
            while (i < length) {
                if (StringsKt.contains$default((CharSequence) str2, str.charAt(i), false, 2, (Object) null)) {
                    return i;
                }
                i++;
            }
            return str.length();
        }
    }
}
