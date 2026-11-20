.class public final Lcom/scanflow/datacapture/utils/ErrorMessageUtils;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final Error_0:Ljava/lang/String; = "Please wait while your license key is being verified"

.field public static final Error_12:Ljava/lang/String; = "Error 12 - License Key Missing\nNo License key was set. Please set a valid license key"

.field public static final Error_13:Ljava/lang/String; = "Error 13 - License Key Expired\nThe license key validation failed. Your license key has expired, please log into your account at www.scanflow.ai and request an extension or contact support through this contact form."

.field public static final Error_19:Ljava/lang/String; = "Error 19 - Device Activation Failed\nThe device activation failed. Please connect to the Internet and restart the app."

.field public static final Error_9:Ljava/lang/String; = "Error 9, Error 10, Error 11 - Validation Failed\nPlease check your internet connection or contact administrator."

.field public static final INSTANCE:Lcom/scanflow/datacapture/utils/ErrorMessageUtils;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/utils/ErrorMessageUtils;

    invoke-direct {v0}, Lcom/scanflow/datacapture/utils/ErrorMessageUtils;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/utils/ErrorMessageUtils;->INSTANCE:Lcom/scanflow/datacapture/utils/ErrorMessageUtils;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
