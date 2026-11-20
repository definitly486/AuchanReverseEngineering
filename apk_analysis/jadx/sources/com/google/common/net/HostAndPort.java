package com.google.common.net;

import com.google.common.annotations.GwtCompatible;
import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import com.google.common.base.Preconditions;
import com.google.common.base.Strings;
import com.google.common.primitives.Ints;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import java.io.Serializable;
import java.util.Objects;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
@GwtCompatible
public final class HostAndPort implements Serializable {
    private static final int NO_PORT = -1;

    @J2ktIncompatible
    @GwtIncompatible
    private static final long serialVersionUID = 0;
    private final boolean hasBracketlessColons;
    private final String host;
    private final int port;

    private static boolean isValidPort(int i) {
        return i >= 0 && i <= 65535;
    }

    private HostAndPort(String str, int i, boolean z) {
        this.host = str;
        this.port = i;
        this.hasBracketlessColons = z;
    }

    public String getHost() {
        return this.host;
    }

    public boolean hasPort() {
        return this.port >= 0;
    }

    public int getPort() {
        Preconditions.checkState(hasPort());
        return this.port;
    }

    public int getPortOrDefault(int i) {
        return hasPort() ? this.port : i;
    }

    public static HostAndPort fromParts(String str, int i) {
        Preconditions.checkArgument(isValidPort(i), "Port out of range: %s", i);
        HostAndPort hostAndPortFromString = fromString(str);
        Preconditions.checkArgument(!hostAndPortFromString.hasPort(), "Host has a port: %s", str);
        return new HostAndPort(hostAndPortFromString.host, i, hostAndPortFromString.hasBracketlessColons);
    }

    public static HostAndPort fromHost(String str) {
        HostAndPort hostAndPortFromString = fromString(str);
        Preconditions.checkArgument(!hostAndPortFromString.hasPort(), "Host has a port: %s", str);
        return hostAndPortFromString;
    }

    /* JADX WARN: Code duplicated, block: B:17:0x0042  */
    /* JADX WARN: Code duplicated, block: B:18:0x0047  */
    /* JADX WARN: Code duplicated, block: B:21:0x004e  */
    @CanIgnoreReturnValue
    public static HostAndPort fromString(String str) {
        boolean z;
        String strSubstring;
        String str2;
        String strSubstring2;
        Integer num;
        Preconditions.checkNotNull(str);
        if (str.startsWith("[")) {
            String[] hostAndPortFromBracketedHost = getHostAndPortFromBracketedHost(str);
            strSubstring2 = hostAndPortFromBracketedHost[0];
            strSubstring = hostAndPortFromBracketedHost[1];
        } else {
            int iIndexOf = str.indexOf(58);
            if (iIndexOf >= 0) {
                int i = iIndexOf + 1;
                if (str.indexOf(58, i) == -1) {
                    strSubstring2 = str.substring(0, iIndexOf);
                    strSubstring = str.substring(i);
                }
                if (Strings.isNullOrEmpty(strSubstring)) {
                    num = -1;
                } else {
                    Integer numTryParse = Ints.tryParse(strSubstring);
                    Preconditions.checkArgument(numTryParse != null, "Unparseable port number: %s", str);
                    Preconditions.checkArgument(isValidPort(numTryParse.intValue()), "Port number out of range: %s", str);
                    num = numTryParse;
                }
                return new HostAndPort(str2, num.intValue(), z);
            }
            z = iIndexOf >= 0;
            strSubstring = null;
            str2 = str;
            if (Strings.isNullOrEmpty(strSubstring)) {
                num = -1;
            } else {
                Integer numTryParse2 = Ints.tryParse(strSubstring);
                Preconditions.checkArgument(numTryParse2 != null, "Unparseable port number: %s", str);
                Preconditions.checkArgument(isValidPort(numTryParse2.intValue()), "Port number out of range: %s", str);
                num = numTryParse2;
            }
            return new HostAndPort(str2, num.intValue(), z);
        }
        str2 = strSubstring2;
        z = false;
        if (Strings.isNullOrEmpty(strSubstring)) {
            num = -1;
        } else {
            Integer numTryParse3 = Ints.tryParse(strSubstring);
            Preconditions.checkArgument(numTryParse3 != null, "Unparseable port number: %s", str);
            Preconditions.checkArgument(isValidPort(numTryParse3.intValue()), "Port number out of range: %s", str);
            num = numTryParse3;
        }
        return new HostAndPort(str2, num.intValue(), z);
    }

    private static String[] getHostAndPortFromBracketedHost(String str) {
        Preconditions.checkArgument(str.charAt(0) == '[', "Bracketed host-port string must start with a bracket: %s", str);
        int iIndexOf = str.indexOf(58);
        int iLastIndexOf = str.lastIndexOf(93);
        Preconditions.checkArgument(iIndexOf > -1 && iLastIndexOf > iIndexOf, "Invalid bracketed host/port: %s", str);
        String strSubstring = str.substring(1, iLastIndexOf);
        int i = iLastIndexOf + 1;
        if (i == str.length()) {
            return new String[]{strSubstring, ""};
        }
        Preconditions.checkArgument(str.charAt(i) == ':', "Only a colon may follow a close bracket: %s", str);
        int i2 = iLastIndexOf + 2;
        for (int i3 = i2; i3 < str.length(); i3++) {
            Preconditions.checkArgument(Character.isDigit(str.charAt(i3)), "Port must be numeric: %s", str);
        }
        return new String[]{strSubstring, str.substring(i2)};
    }

    public HostAndPort withDefaultPort(int i) {
        Preconditions.checkArgument(isValidPort(i));
        return hasPort() ? this : new HostAndPort(this.host, i, this.hasBracketlessColons);
    }

    @CanIgnoreReturnValue
    public HostAndPort requireBracketsForIPv6() {
        Preconditions.checkArgument(!this.hasBracketlessColons, "Possible bracketless IPv6 literal: %s", this.host);
        return this;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj instanceof HostAndPort) {
            HostAndPort hostAndPort = (HostAndPort) obj;
            if (Objects.equals(this.host, hostAndPort.host) && this.port == hostAndPort.port) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return Objects.hash(this.host, Integer.valueOf(this.port));
    }

    public String toString() {
        StringBuilder sb = new StringBuilder(this.host.length() + 8);
        if (this.host.indexOf(58) >= 0) {
            sb.append('[');
            sb.append(this.host);
            sb.append(']');
        } else {
            sb.append(this.host);
        }
        if (hasPort()) {
            sb.append(':');
            sb.append(this.port);
        }
        return sb.toString();
    }
}
