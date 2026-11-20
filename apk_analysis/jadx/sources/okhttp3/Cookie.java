package okhttp3;

import androidx.core.location.LocationRequestCompat;
import com.google.common.net.HttpHeaders;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Regex;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.Locale;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.internal.HostnamesKt;
import okhttp3.internal.Util;
import okhttp3.internal.http.DatesKt;
import okhttp3.internal.publicsuffix.PublicSuffixDatabase;
import org.codehaus.mojo.animal_sniffer.IgnoreJRERequirement;

/* JADX INFO: compiled from: Cookie.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Cookie {
    private final String domain;
    private final long expiresAt;
    private final boolean hostOnly;
    private final boolean httpOnly;
    private final String name;
    private final String path;
    private final boolean persistent;
    private final boolean secure;
    private final String value;
    public static final Companion Companion = new Companion(null);
    private static final Pattern YEAR_PATTERN = Pattern.compile("(\\d{2,4})[^\\d]*");
    private static final Pattern MONTH_PATTERN = Pattern.compile("(?i)(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec).*");
    private static final Pattern DAY_OF_MONTH_PATTERN = Pattern.compile("(\\d{1,2})[^\\d]*");
    private static final Pattern TIME_PATTERN = Pattern.compile("(\\d{1,2}):(\\d{1,2}):(\\d{1,2})[^\\d]*");

    public /* synthetic */ Cookie(String str, String str2, long j, String str3, String str4, boolean z, boolean z2, boolean z3, boolean z4, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, str2, j, str3, str4, z, z2, z3, z4);
    }

    public static final Cookie parse(HttpUrl httpUrl, String str) {
        return Companion.parse(httpUrl, str);
    }

    public static final List<Cookie> parseAll(HttpUrl httpUrl, Headers headers) {
        return Companion.parseAll(httpUrl, headers);
    }

    private Cookie(String str, String str2, long j, String str3, String str4, boolean z, boolean z2, boolean z3, boolean z4) {
        this.name = str;
        this.value = str2;
        this.expiresAt = j;
        this.domain = str3;
        this.path = str4;
        this.secure = z;
        this.httpOnly = z2;
        this.persistent = z3;
        this.hostOnly = z4;
    }

    public final String name() {
        return this.name;
    }

    public final String value() {
        return this.value;
    }

    public final long expiresAt() {
        return this.expiresAt;
    }

    public final String domain() {
        return this.domain;
    }

    public final String path() {
        return this.path;
    }

    public final boolean secure() {
        return this.secure;
    }

    public final boolean httpOnly() {
        return this.httpOnly;
    }

    public final boolean persistent() {
        return this.persistent;
    }

    public final boolean hostOnly() {
        return this.hostOnly;
    }

    public final boolean matches(HttpUrl url) {
        boolean zDomainMatch;
        Intrinsics.checkNotNullParameter(url, "url");
        if (this.hostOnly) {
            zDomainMatch = Intrinsics.areEqual(url.host(), this.domain);
        } else {
            zDomainMatch = Companion.domainMatch(url.host(), this.domain);
        }
        if (zDomainMatch && Companion.pathMatch(url, this.path)) {
            return !this.secure || url.isHttps();
        }
        return false;
    }

    public boolean equals(Object obj) {
        if (!(obj instanceof Cookie)) {
            return false;
        }
        Cookie cookie = (Cookie) obj;
        return Intrinsics.areEqual(cookie.name, this.name) && Intrinsics.areEqual(cookie.value, this.value) && cookie.expiresAt == this.expiresAt && Intrinsics.areEqual(cookie.domain, this.domain) && Intrinsics.areEqual(cookie.path, this.path) && cookie.secure == this.secure && cookie.httpOnly == this.httpOnly && cookie.persistent == this.persistent && cookie.hostOnly == this.hostOnly;
    }

    @IgnoreJRERequirement
    public int hashCode() {
        return ((((((((((((((((527 + this.name.hashCode()) * 31) + this.value.hashCode()) * 31) + Long.hashCode(this.expiresAt)) * 31) + this.domain.hashCode()) * 31) + this.path.hashCode()) * 31) + Boolean.hashCode(this.secure)) * 31) + Boolean.hashCode(this.httpOnly)) * 31) + Boolean.hashCode(this.persistent)) * 31) + Boolean.hashCode(this.hostOnly);
    }

    public String toString() {
        return toString$okhttp(false);
    }

    /* JADX INFO: renamed from: -deprecated_name, reason: not valid java name */
    public final String m1032deprecated_name() {
        return this.name;
    }

    /* JADX INFO: renamed from: -deprecated_value, reason: not valid java name */
    public final String m1036deprecated_value() {
        return this.value;
    }

    /* JADX INFO: renamed from: -deprecated_persistent, reason: not valid java name */
    public final boolean m1034deprecated_persistent() {
        return this.persistent;
    }

    /* JADX INFO: renamed from: -deprecated_expiresAt, reason: not valid java name */
    public final long m1029deprecated_expiresAt() {
        return this.expiresAt;
    }

    /* JADX INFO: renamed from: -deprecated_hostOnly, reason: not valid java name */
    public final boolean m1030deprecated_hostOnly() {
        return this.hostOnly;
    }

    /* JADX INFO: renamed from: -deprecated_domain, reason: not valid java name */
    public final String m1028deprecated_domain() {
        return this.domain;
    }

    /* JADX INFO: renamed from: -deprecated_path, reason: not valid java name */
    public final String m1033deprecated_path() {
        return this.path;
    }

    /* JADX INFO: renamed from: -deprecated_httpOnly, reason: not valid java name */
    public final boolean m1031deprecated_httpOnly() {
        return this.httpOnly;
    }

    /* JADX INFO: renamed from: -deprecated_secure, reason: not valid java name */
    public final boolean m1035deprecated_secure() {
        return this.secure;
    }

    public final String toString$okhttp(boolean z) {
        StringBuilder sb = new StringBuilder();
        sb.append(this.name);
        sb.append('=');
        sb.append(this.value);
        if (this.persistent) {
            if (this.expiresAt == Long.MIN_VALUE) {
                sb.append("; max-age=0");
            } else {
                sb.append("; expires=");
                sb.append(DatesKt.toHttpDateString(new Date(this.expiresAt)));
            }
        }
        if (!this.hostOnly) {
            sb.append("; domain=");
            if (z) {
                sb.append(".");
            }
            sb.append(this.domain);
        }
        sb.append("; path=");
        sb.append(this.path);
        if (this.secure) {
            sb.append("; secure");
        }
        if (this.httpOnly) {
            sb.append("; httponly");
        }
        String string = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string, "toString()");
        return string;
    }

    /* JADX INFO: compiled from: Cookie.kt */
    public static final class Builder {
        private String domain;
        private boolean hostOnly;
        private boolean httpOnly;
        private String name;
        private boolean persistent;
        private boolean secure;
        private String value;
        private long expiresAt = DatesKt.MAX_DATE;
        private String path = "/";

        public final Builder name(String name) {
            Intrinsics.checkNotNullParameter(name, "name");
            if (!Intrinsics.areEqual(StringsKt.trim(name).toString(), name)) {
                throw new IllegalArgumentException("name is not trimmed");
            }
            this.name = name;
            return this;
        }

        public final Builder value(String value) {
            Intrinsics.checkNotNullParameter(value, "value");
            if (!Intrinsics.areEqual(StringsKt.trim(value).toString(), value)) {
                throw new IllegalArgumentException("value is not trimmed");
            }
            this.value = value;
            return this;
        }

        public final Builder expiresAt(long j) {
            if (j <= 0) {
                j = Long.MIN_VALUE;
            }
            if (j > DatesKt.MAX_DATE) {
                j = 253402300799999L;
            }
            this.expiresAt = j;
            this.persistent = true;
            return this;
        }

        public final Builder domain(String domain) {
            Intrinsics.checkNotNullParameter(domain, "domain");
            return domain(domain, false);
        }

        public final Builder hostOnlyDomain(String domain) {
            Intrinsics.checkNotNullParameter(domain, "domain");
            return domain(domain, true);
        }

        private final Builder domain(String str, boolean z) {
            String canonicalHost = HostnamesKt.toCanonicalHost(str);
            if (canonicalHost == null) {
                throw new IllegalArgumentException("unexpected domain: " + str);
            }
            this.domain = canonicalHost;
            this.hostOnly = z;
            return this;
        }

        public final Builder path(String path) {
            Intrinsics.checkNotNullParameter(path, "path");
            if (!StringsKt.startsWith$default(path, "/", false, 2, (Object) null)) {
                throw new IllegalArgumentException("path must start with '/'");
            }
            this.path = path;
            return this;
        }

        public final Builder secure() {
            this.secure = true;
            return this;
        }

        public final Builder httpOnly() {
            this.httpOnly = true;
            return this;
        }

        public final Cookie build() {
            String str = this.name;
            if (str == null) {
                throw new NullPointerException("builder.name == null");
            }
            String str2 = this.value;
            if (str2 == null) {
                throw new NullPointerException("builder.value == null");
            }
            long j = this.expiresAt;
            String str3 = this.domain;
            if (str3 != null) {
                return new Cookie(str, str2, j, str3, this.path, this.secure, this.httpOnly, this.persistent, this.hostOnly, null);
            }
            throw new NullPointerException("builder.domain == null");
        }
    }

    /* JADX INFO: compiled from: Cookie.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX INFO: Access modifiers changed from: private */
        public final boolean domainMatch(String str, String str2) {
            if (Intrinsics.areEqual(str, str2)) {
                return true;
            }
            return StringsKt.endsWith$default(str, str2, false, 2, (Object) null) && str.charAt((str.length() - str2.length()) - 1) == '.' && !Util.canParseAsIpAddress(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public final boolean pathMatch(HttpUrl httpUrl, String str) {
            String strEncodedPath = httpUrl.encodedPath();
            if (Intrinsics.areEqual(strEncodedPath, str)) {
                return true;
            }
            return StringsKt.startsWith$default(strEncodedPath, str, false, 2, (Object) null) && (StringsKt.endsWith$default(str, "/", false, 2, (Object) null) || strEncodedPath.charAt(str.length()) == '/');
        }

        public final Cookie parse(HttpUrl url, String setCookie) {
            Intrinsics.checkNotNullParameter(url, "url");
            Intrinsics.checkNotNullParameter(setCookie, "setCookie");
            return parse$okhttp(System.currentTimeMillis(), url, setCookie);
        }

        public final Cookie parse$okhttp(long j, HttpUrl url, String setCookie) {
            long j2;
            String strTrimSubstring;
            Intrinsics.checkNotNullParameter(url, "url");
            Intrinsics.checkNotNullParameter(setCookie, "setCookie");
            int iDelimiterOffset$default = Util.delimiterOffset$default(setCookie, ';', 0, 0, 6, (Object) null);
            int iDelimiterOffset$default2 = Util.delimiterOffset$default(setCookie, '=', 0, iDelimiterOffset$default, 2, (Object) null);
            Cookie cookie = null;
            if (iDelimiterOffset$default2 == iDelimiterOffset$default) {
                return null;
            }
            String strTrimSubstring$default = Util.trimSubstring$default(setCookie, 0, iDelimiterOffset$default2, 1, null);
            if (strTrimSubstring$default.length() == 0 || Util.indexOfControlOrNonAscii(strTrimSubstring$default) != -1) {
                return null;
            }
            String strTrimSubstring2 = Util.trimSubstring(setCookie, iDelimiterOffset$default2 + 1, iDelimiterOffset$default);
            if (Util.indexOfControlOrNonAscii(strTrimSubstring2) != -1) {
                return null;
            }
            int i = iDelimiterOffset$default + 1;
            int length = setCookie.length();
            String domain = null;
            String str = null;
            boolean z = false;
            boolean z2 = false;
            boolean z3 = false;
            boolean z4 = true;
            long maxAge = -1;
            long expires = DatesKt.MAX_DATE;
            while (i < length) {
                int iDelimiterOffset = Util.delimiterOffset(setCookie, ';', i, length);
                int iDelimiterOffset2 = Util.delimiterOffset(setCookie, '=', i, iDelimiterOffset);
                String strTrimSubstring3 = Util.trimSubstring(setCookie, i, iDelimiterOffset2);
                if (iDelimiterOffset2 < iDelimiterOffset) {
                    strTrimSubstring = Util.trimSubstring(setCookie, iDelimiterOffset2 + 1, iDelimiterOffset);
                } else {
                    strTrimSubstring = "";
                }
                Cookie cookie2 = cookie;
                if (StringsKt.equals(strTrimSubstring3, "expires", true)) {
                    try {
                        expires = parseExpires(strTrimSubstring, 0, strTrimSubstring.length());
                        z2 = true;
                    } catch (NumberFormatException | IllegalArgumentException unused) {
                    }
                } else if (StringsKt.equals(strTrimSubstring3, "max-age", true)) {
                    maxAge = parseMaxAge(strTrimSubstring);
                    z2 = true;
                } else if (StringsKt.equals(strTrimSubstring3, "domain", true)) {
                    domain = parseDomain(strTrimSubstring);
                    z4 = false;
                } else if (StringsKt.equals(strTrimSubstring3, "path", true)) {
                    str = strTrimSubstring;
                } else if (StringsKt.equals(strTrimSubstring3, "secure", true)) {
                    z3 = true;
                } else if (StringsKt.equals(strTrimSubstring3, "httponly", true)) {
                    z = true;
                }
                i = iDelimiterOffset + 1;
                cookie = cookie2;
            }
            Cookie cookie3 = cookie;
            if (maxAge == Long.MIN_VALUE) {
                j2 = Long.MIN_VALUE;
            } else if (maxAge != -1) {
                long j3 = j + (maxAge <= 9223372036854775L ? maxAge * ((long) 1000) : LocationRequestCompat.PASSIVE_INTERVAL);
                j2 = (j3 < j || j3 > DatesKt.MAX_DATE) ? 253402300799999L : j3;
            } else {
                j2 = expires;
            }
            String strHost = url.host();
            if (domain == null) {
                domain = strHost;
            } else if (!domainMatch(strHost, domain)) {
                return cookie3;
            }
            if (strHost.length() != domain.length() && PublicSuffixDatabase.Companion.get().getEffectiveTldPlusOne(domain) == null) {
                return cookie3;
            }
            String strSubstring = "/";
            if (str == null || !StringsKt.startsWith$default(str, "/", false, 2, (Object) cookie3)) {
                String strEncodedPath = url.encodedPath();
                int iLastIndexOf$default = StringsKt.lastIndexOf$default((CharSequence) strEncodedPath, '/', 0, false, 6, (Object) null);
                if (iLastIndexOf$default != 0) {
                    strSubstring = strEncodedPath.substring(0, iLastIndexOf$default);
                    Intrinsics.checkNotNullExpressionValue(strSubstring, "this as java.lang.String…ing(startIndex, endIndex)");
                }
                str = strSubstring;
            }
            return new Cookie(strTrimSubstring$default, strTrimSubstring2, j2, domain, str, z3, z, z2, z4, null);
        }

        private final long parseExpires(String str, int i, int i2) {
            int iDateCharacterOffset = dateCharacterOffset(str, i, i2, false);
            Matcher matcher = Cookie.TIME_PATTERN.matcher(str);
            int i3 = -1;
            int i4 = -1;
            int i5 = -1;
            int iIndexOf$default = -1;
            int i6 = -1;
            int i7 = -1;
            while (iDateCharacterOffset < i2) {
                int iDateCharacterOffset2 = dateCharacterOffset(str, iDateCharacterOffset + 1, i2, true);
                matcher.region(iDateCharacterOffset, iDateCharacterOffset2);
                if (i4 != -1 || !matcher.usePattern(Cookie.TIME_PATTERN).matches()) {
                    if (i5 != -1 || !matcher.usePattern(Cookie.DAY_OF_MONTH_PATTERN).matches()) {
                        if (iIndexOf$default != -1 || !matcher.usePattern(Cookie.MONTH_PATTERN).matches()) {
                            if (i3 == -1 && matcher.usePattern(Cookie.YEAR_PATTERN).matches()) {
                                String strGroup = matcher.group(1);
                                Intrinsics.checkNotNullExpressionValue(strGroup, "matcher.group(1)");
                                i3 = Integer.parseInt(strGroup);
                            }
                        } else {
                            String strGroup2 = matcher.group(1);
                            Intrinsics.checkNotNullExpressionValue(strGroup2, "matcher.group(1)");
                            Locale US = Locale.US;
                            Intrinsics.checkNotNullExpressionValue(US, "US");
                            String lowerCase = strGroup2.toLowerCase(US);
                            Intrinsics.checkNotNullExpressionValue(lowerCase, "this as java.lang.String).toLowerCase(locale)");
                            String strPattern = Cookie.MONTH_PATTERN.pattern();
                            Intrinsics.checkNotNullExpressionValue(strPattern, "MONTH_PATTERN.pattern()");
                            iIndexOf$default = StringsKt.indexOf$default((CharSequence) strPattern, lowerCase, 0, false, 6, (Object) null) / 4;
                        }
                    } else {
                        String strGroup3 = matcher.group(1);
                        Intrinsics.checkNotNullExpressionValue(strGroup3, "matcher.group(1)");
                        i5 = Integer.parseInt(strGroup3);
                    }
                } else {
                    String strGroup4 = matcher.group(1);
                    Intrinsics.checkNotNullExpressionValue(strGroup4, "matcher.group(1)");
                    i4 = Integer.parseInt(strGroup4);
                    String strGroup5 = matcher.group(2);
                    Intrinsics.checkNotNullExpressionValue(strGroup5, "matcher.group(2)");
                    i6 = Integer.parseInt(strGroup5);
                    String strGroup6 = matcher.group(3);
                    Intrinsics.checkNotNullExpressionValue(strGroup6, "matcher.group(3)");
                    i7 = Integer.parseInt(strGroup6);
                }
                iDateCharacterOffset = dateCharacterOffset(str, iDateCharacterOffset2 + 1, i2, false);
            }
            if (70 <= i3 && i3 < 100) {
                i3 += 1900;
            }
            if (i3 >= 0 && i3 < 70) {
                i3 += 2000;
            }
            if (i3 < 1601) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            if (iIndexOf$default == -1) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            if (1 > i5 || i5 >= 32) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            if (i4 < 0 || i4 >= 24) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            if (i6 < 0 || i6 >= 60) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            if (i7 < 0 || i7 >= 60) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            GregorianCalendar gregorianCalendar = new GregorianCalendar(Util.UTC);
            gregorianCalendar.setLenient(false);
            gregorianCalendar.set(1, i3);
            gregorianCalendar.set(2, iIndexOf$default - 1);
            gregorianCalendar.set(5, i5);
            gregorianCalendar.set(11, i4);
            gregorianCalendar.set(12, i6);
            gregorianCalendar.set(13, i7);
            gregorianCalendar.set(14, 0);
            return gregorianCalendar.getTimeInMillis();
        }

        private final int dateCharacterOffset(String str, int i, int i2, boolean z) {
            while (i < i2) {
                char cCharAt = str.charAt(i);
                if (((cCharAt < ' ' && cCharAt != '\t') || cCharAt >= 127 || ('0' <= cCharAt && cCharAt < ':') || (('a' <= cCharAt && cCharAt < '{') || (('A' <= cCharAt && cCharAt < '[') || cCharAt == ':'))) == (!z)) {
                    return i;
                }
                i++;
            }
            return i2;
        }

        private final long parseMaxAge(String str) {
            try {
                long j = Long.parseLong(str);
                if (j <= 0) {
                    return Long.MIN_VALUE;
                }
                return j;
            } catch (NumberFormatException e) {
                if (new Regex("-?\\d+").matches(str)) {
                    if (StringsKt.startsWith$default(str, "-", false, 2, (Object) null)) {
                        return Long.MIN_VALUE;
                    }
                    return LocationRequestCompat.PASSIVE_INTERVAL;
                }
                throw e;
            }
        }

        private final String parseDomain(String str) {
            if (StringsKt.endsWith$default(str, ".", false, 2, (Object) null)) {
                throw new IllegalArgumentException("Failed requirement.");
            }
            String canonicalHost = HostnamesKt.toCanonicalHost(StringsKt.removePrefix(str, "."));
            if (canonicalHost != null) {
                return canonicalHost;
            }
            throw new IllegalArgumentException();
        }

        public final List<Cookie> parseAll(HttpUrl url, Headers headers) {
            Intrinsics.checkNotNullParameter(url, "url");
            Intrinsics.checkNotNullParameter(headers, "headers");
            List<String> listValues = headers.values(HttpHeaders.SET_COOKIE);
            int size = listValues.size();
            ArrayList arrayList = null;
            for (int i = 0; i < size; i++) {
                Cookie cookie = parse(url, listValues.get(i));
                if (cookie != null) {
                    if (arrayList == null) {
                        arrayList = new ArrayList();
                    }
                    arrayList.add(cookie);
                }
            }
            if (arrayList != null) {
                List<Cookie> listUnmodifiableList = Collections.unmodifiableList(arrayList);
                Intrinsics.checkNotNullExpressionValue(listUnmodifiableList, "{\n        Collections.un…ableList(cookies)\n      }");
                return listUnmodifiableList;
            }
            return CollectionsKt.emptyList();
        }
    }
}
