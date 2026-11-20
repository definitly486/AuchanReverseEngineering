using System.Collections.Generic;

namespace DryIoc;

public delegate IEnumerable<PropertyOrFieldServiceInfo> PropertiesAndFieldsSelector(Request request);
